using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;

namespace AllOut.Api.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AllOutDbContext _db;
        private readonly IRequestService _request;
        public InventoryService(AllOutDbContext context, IRequestService request)
        {
            _db = context;
            _request = request;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesAsync()
        {
            return await _db.Inventories.Where(data => data.Status != Constants.STATUS_DELETION_INT).ToListAsync();
        }

        public async Task<Inventory> GetInventoryByIDAsync(Guid InventoryID)
        {
            var inventory = await _db.Inventories.FindAsync(InventoryID);

            if (inventory == null)
                throw new ServiceException(string.Format(Constants.ERROR_NOT_FOUND, Constants.OBJECT_INVENTORY));

            return inventory;
        }

        public async Task<string> SaveInventoryAsync(SaveInventoryRequest request)
        {
            //Check if Request is NULL
            if (request == null)
                throw new ServiceException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_INVENTORY));

            var requestID = await _request.InsertRequest(_db, request.client.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new ServiceException(string.Format(Constants.ERROR_ID_NULL, Constants.OBJECT_INVENTORY));

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_INVENTORY_BY_ADMIN: //Add
                    await InsertInventory(request.inputInventory);
                    break;
                case Constants.FUNCTION_ID_CHANGE_INVENTORY_BY_ADMIN: //Change
                    await UpdateInventory(request.inputInventory);
                    break;
                default: //Delete
                    await DeleteInventory(request.inputInventory.InventoryID);
                    break;
            }

            //Insert Transaction
            await InsertInventory_TRN(request.inputInventory, requestID.ToString());
            //Save Changes
            await _db.SaveChangesAsync();

            return requestID;
        }

        private async Task InsertInventory(Inventory inputInventory)
        {
            var errorMessage = ValidateInventory(inputInventory);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new ServiceException(errorMessage);
            }

            inputInventory.InventoryID = Guid.NewGuid();
            inputInventory.CreatedDate = Globals.EXEC_DATETIME;
            await _db.Inventories.AddAsync(inputInventory);
        }

        private async Task UpdateInventory(Inventory inputInventory)
        {
            var currentInventory = await _db.Inventories.FindAsync(inputInventory.InventoryID);

            if (currentInventory == null)
                throw new ServiceException(string.Format(Constants.ERROR_NOT_FOUND_CHANGE, Constants.OBJECT_INVENTORY));

            var errorMessage = ValidateInventory(inputInventory, currentInventory);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new ServiceException(errorMessage);
            }

            //currentInventory.InventoryID = inputInventory.InventoryID;
            currentInventory.ProductID = inputInventory.ProductID;
            currentInventory.Quantity = inputInventory.Quantity;
            currentInventory.Status = inputInventory.Status;
            //currentInventory.CreatedDate = inputInventory.CreatedDate;
            currentInventory.ModifiedDate = Globals.EXEC_DATETIME;
        }

        private async Task DeleteInventory(Guid InventoryID)
        {
            var currentInventory = await _db.Inventories.FindAsync(InventoryID);

            if (currentInventory == null)
                throw new ServiceException(string.Format(Constants.ERROR_NOT_FOUND_DELETE, Constants.OBJECT_CATEGORY));

            _db.Inventories.Remove(currentInventory);
        }

        private async Task InsertInventory_TRN(Inventory inputInventory, string requestID, int number = 1)
        {
            var newTrn = new Inventory_TRN
            {
                RequestID = requestID,
                Number = number,
                InventoryID = inputInventory.InventoryID,
                ProductID = inputInventory.ProductID,
                Quantity = inputInventory.Quantity,
                Status = inputInventory.Status,
                CreatedDate = inputInventory.CreatedDate,
                ModifiedDate = inputInventory.ModifiedDate
            };

            await _db.Inventory_TRN.AddAsync(newTrn);
        }

        private string ValidateInventory(Inventory newData, Inventory? oldData = null)
        {
            //Check Data if NULL
            if (newData == null)
                return string.Format(Constants.ERROR_NULL, Constants.OBJECT_INVENTORY);

            if (oldData != null)
            {
                //Check if new data and old data changed
                if (newData.ProductID == oldData.ProductID &&
                    newData.Quantity == oldData.Quantity &&
                    newData.Status == oldData.Status &&
                    newData.CreatedDate == oldData.CreatedDate &&
                    newData.ModifiedDate == oldData.ModifiedDate)
                    return string.Format(Constants.ERROR_NO_CHANGES, Constants.OBJECT_PRODUCT);
            }

            var isItemExist = _db.Products.Where(data => data.ProductID == newData.ProductID).ToList();
            if (!isItemExist.Any())
            {
                return Constants.ERROR_PRODUCT_NOT_EXIST;
            }

            return string.Empty;
        }
    }
}
