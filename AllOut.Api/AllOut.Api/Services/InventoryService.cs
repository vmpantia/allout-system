using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;
using AllOut.Api.Models;

namespace AllOut.Api.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AllOutDbContext _db;
        private readonly IRequestService _request;
        private readonly IUtilityService _utility;
        public InventoryService(AllOutDbContext context, IRequestService request, IUtilityService utility)
        {
            _db = context;
            _request = request;
            _utility = utility;
        }

        #region Public Methods
        public async Task<IEnumerable<InventoryFullInformation>> GetInventoriesAsync()
        {
            var inventories = await (from a in _db.Inventories
                                     join b in _db.Products on a.ProductID equals b.ProductID into bb
                                     from b in bb.DefaultIfEmpty()
                                     join c in _db.Brands on b.BrandID equals c.BrandID into cc
                                     from c in cc.DefaultIfEmpty()
                                     join d in _db.Categories on b.CategoryID equals d.CategoryID into dd
                                     from d in dd.DefaultIfEmpty()
                                     where a.Status != Constants.STATUS_DELETION_INT
                                     select new InventoryFullInformation
                                     {
                                         InventoryID = a.InventoryID,
                                         Quantity = a.Quantity,
                                         Status = a.Status,
                                         CreatedDate = a.CreatedDate,
                                         ModifiedDate = b.ModifiedDate,
                                         ProductID = a.ProductID,
                                         ProductName = _utility.CheckProductAvailablity(b) ? b.Name : Constants.NA,
                                         BrandID = _utility.CheckBrandAvailablity(c) ? c.BrandID : Guid.Empty,
                                         BrandName = _utility.CheckBrandAvailablity(c) ? c.Name : Constants.NA,
                                         CategoryID = _utility.CheckCategoryAvailablity(d) ? d.CategoryID : Guid.Empty,
                                         CategoryName = _utility.CheckCategoryAvailablity(d) ? d.Name : Constants.NA
                                     }).ToListAsync();

            return inventories;
        }

        public async Task<IEnumerable<InventoryFullInformation>> GetInventoriesByQueryAsync(string query)
        {
            var inventories = await (from a in _db.Inventories
                                     join b in _db.Products on a.ProductID equals b.ProductID into bb from b in bb.DefaultIfEmpty()
                                     join c in _db.Brands on b.BrandID equals c.BrandID into cc from c in cc.DefaultIfEmpty()
                                     join d in _db.Categories on b.CategoryID equals d.CategoryID into dd from d in dd.DefaultIfEmpty()
                                     where a.Status != Constants.STATUS_DELETION_INT &&
                                           (a.InventoryID.Contains(query) || b.Name.Contains(query) || c.Name.Contains(query) || d.Name.Contains(query))
                                     select new InventoryFullInformation
                                     {
                                         InventoryID = a.InventoryID,
                                         Quantity = a.Quantity,
                                         Status = a.Status,
                                         CreatedDate = a.CreatedDate,
                                         ModifiedDate = b.ModifiedDate,
                                         ProductID = a.ProductID,
                                         ProductName = _utility.CheckProductAvailablity(b) ? b.Name : Constants.NA,
                                         BrandID = _utility.CheckBrandAvailablity(c) ? c.BrandID : Guid.Empty,
                                         BrandName = _utility.CheckBrandAvailablity(c) ? c.Name : Constants.NA,
                                         CategoryID = _utility.CheckCategoryAvailablity(d) ? d.CategoryID : Guid.Empty,
                                         CategoryName = _utility.CheckCategoryAvailablity(d) ? d.Name : Constants.NA
                                     }).ToListAsync();

            return inventories;
        }

        public async Task<Inventory> GetInventoryByIDAsync(string InventoryID)
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
                case Constants.FUNCTION_ID_DELETE_INVENTORY_BY_ADMIN: //Delete
                    await DeleteInventory(request.inputInventory.InventoryID);
                    break;
            }

            //Insert Transaction
            await InsertInventory_TRN(request.inputInventory, requestID.ToString());
            //Save Changes
            await _db.SaveChangesAsync();

            return requestID;
        }
        #endregion

        #region Private Methods
        private async Task InsertInventory(Inventory inputInventory)
        {
            var errorMessage = ValidateInventory(inputInventory);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new ServiceException(errorMessage);
            }

            inputInventory.InventoryID = await GetNewInventoryID();
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

        private async Task DeleteInventory(string InventoryID)
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
                return Constants.ERROR_PRODUCT_NOT_EXIST;

            return string.Empty;
        }

        private async Task<string> GetNewInventoryID()
        {
            var inventoriesToday = await _db.Inventories.Where(data => data.CreatedDate == DateTime.Parse(Globals.EXEC_DATE))
                                                       .OrderByDescending(data => data.InventoryID).ToListAsync();

            if (inventoriesToday == null || !inventoriesToday.Any())
                return string.Format(Constants.INVENTORY_ID_FORMAT, Globals.ID_PREFFIX, Constants.ID_DEFAULT_SUFFIX);

            var latestInventoryID = inventoriesToday.First().InventoryID;
            var currentSuffix = latestInventoryID.Substring(Constants.ID_PREFIX_LENGTH, Constants.ID_SUFFIX_LENGTH);
            var newSuffix = (int.Parse(currentSuffix) + 1).ToString().PadLeft(Constants.ID_SUFFIX_LENGTH, Constants.ZERO);

            return string.Format(Constants.INVENTORY_ID_FORMAT, Globals.ID_PREFFIX, newSuffix);
        }
        #endregion
    }
}
