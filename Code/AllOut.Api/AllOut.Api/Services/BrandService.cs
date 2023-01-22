using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;

namespace AllOut.Api.Services
{
    public class BrandService : IBrandService
    {
        private readonly AllOutDbContext _db;
        private readonly IRequestService _request;
        public BrandService(AllOutDbContext context, IRequestService request)
        {
            _db = context;
            _request = request;
        }

        #region Public Methods
        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            var brands = await _db.Brands.Where(data => data.Status != Constants.STATUS_DELETION_INT).ToListAsync();
            return brands;
        }

        public async Task<IEnumerable<Brand>> GetBrandsByQueryAsync(string query)
        {
            var brands = await _db.Brands.Where(data => data.Name.Contains(query))
                                         .Where(data => data.Status != Constants.STATUS_DELETION_INT).ToListAsync();
            return brands;
        }

        public async Task<IEnumerable<Brand>> GetBrandsByStatusAsync(int status)
        {
            var brands = await _db.Brands.Where(data => data.Status == status).ToListAsync();
            return brands;
        }

        public async Task<Brand> GetBrandByIDAsync(Guid BrandID)
        {
            var brand = await _db.Brands.FindAsync(BrandID);

            if (brand == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND, Constants.OBJECT_BRAND));

            return brand;
        }

        public async Task<int> GetCountBrandsAsync()
        {
            var count = await _db.Brands.Where(data => data.Status != Constants.STATUS_DELETION_INT).CountAsync();
            return count;
        }

        public async Task<int> GetCountBrandsByStatusAsync(int status)
        {
            var count = await _db.Brands.Where(data => data.Status == status).CountAsync();
            return count;
        }

        public async Task<string> SaveBrandAsync(SaveBrandRequest request)
        {
            //Check if Request is NULL
            if (request == null)
                throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_CATEGORY));

            var requestID = await _request.InsertRequest(_db, request.client.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new APIException(string.Format(Constants.ERROR_ID_NULL, Constants.OBJECT_BRAND));

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_BRAND_BY_ADMIN: //Add
                    await InsertBrand(request.inputBrand);
                    break;
                case Constants.FUNCTION_ID_CHANGE_BRAND_BY_ADMIN: //Change
                    await UpdateBrand(request.inputBrand);
                    break;
                case Constants.FUNCTION_ID_DELETE_BRAND_BY_ADMIN: //Delete
                    await DeleteBrand(request.inputBrand.BrandID);
                    break;
            }

            //Insert Transaction
            await InsertBrand_TRN(request.inputBrand, requestID.ToString());
            //Save Changes
            await _db.SaveChangesAsync();

            return requestID;
        }

        public async Task<string> UpdateBrandStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            var requestID = await _request.InsertRequest(_db, request.client.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);
            var count = 0;
            foreach(var id in request.IDs)
            {
                count++;
                var brand = await _db.Brands.FindAsync(id);
                if(brand != null)
                {
                    brand.Status = request.newStatus;
                    brand.ModifiedDate = DateTime.Now;
                    await InsertBrand_TRN(brand, requestID.ToString(), count);
                }
            }

            await _db.SaveChangesAsync();

            return requestID;
        }
        #endregion

        #region Private Methods
        private async Task InsertBrand(Brand inputBrand)
        {
            var errorMessage = await ValidateBrand(inputBrand);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new APIException(errorMessage);
            }

            inputBrand.BrandID = Guid.NewGuid();
            inputBrand.CreatedDate = DateTime.Now;
            await _db.Brands.AddAsync(inputBrand);
        }

        private async Task UpdateBrand(Brand inputBrand)
        {
            var currentBrand = await _db.Brands.FindAsync(inputBrand.BrandID);

            if (currentBrand == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND_CHANGE, Constants.OBJECT_BRAND));

            var errorMessage = await ValidateBrand(inputBrand, currentBrand);
            if(!string.IsNullOrEmpty(errorMessage))
            {
                throw new APIException(errorMessage);
            }

            //currentBrand.BrandID = inputBrand.BrandID;
            currentBrand.Name = inputBrand.Name;
            currentBrand.Description = inputBrand.Description;
            currentBrand.Status = inputBrand.Status;
            //currentBrand.CreatedDate = inputBrand.CreatedDate;
            currentBrand.ModifiedDate = DateTime.Now;
        }

        private async Task DeleteBrand(Guid BrandID)
        {
            var currentBrand = await _db.Brands.FindAsync(BrandID);

            if (currentBrand == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND_DELETE, Constants.OBJECT_BRAND));

            _db.Brands.Remove(currentBrand);
        }

        private async Task InsertBrand_TRN(Brand inputBrand, string requestID, int number = 1)
        {
            var newTrn = new Brand_TRN
            {
                RequestID = requestID,
                Number = number,
                BrandID = inputBrand.BrandID,
                Name = inputBrand.Name,
                Description = inputBrand.Description,
                Status = inputBrand.Status,
                CreatedDate = inputBrand.CreatedDate,
                ModifiedDate = inputBrand.ModifiedDate
            };

            await _db.Brand_TRN.AddAsync(newTrn);
        }

        private async Task<string> ValidateBrand(Brand newData, Brand? oldData = null)
        {
            bool isNew = true;
            bool isNameChanged = false;

            //Check Data if NULL
            if (newData == null)
                return string.Format(Constants.ERROR_NULL, Constants.OBJECT_BRAND);

            //Check if Name have value
            if (string.IsNullOrEmpty(newData.Name))
                return string.Format(Constants.ERROR_NAME_REQUIRED, Constants.OBJECT_BRAND);

            if(oldData != null)
            {
                isNew = false;

                //Check if new data and old data changed
                if (newData.Name == oldData.Name &&
                    newData.Description == oldData.Description &&
                    newData.Status == oldData.Status &&
                    newData.CreatedDate == oldData.CreatedDate &&
                    newData.ModifiedDate == oldData.ModifiedDate)
                    return string.Format(Constants.ERROR_NO_CHANGES, Constants.OBJECT_BRAND);

                isNameChanged = newData.Name != oldData.Name;
            }

            if (isNew || isNameChanged)
            {
                //Check Duplicate Name for New Data
                var duplicate = await _db.Brands.Where(data => data.Name == newData.Name).ToListAsync();

                if (duplicate.Count > 0)
                {
                    if (duplicate.First().Status != Constants.STATUS_ENABLED_INT)
                        return string.Format(Constants.ERROR_NAME_EXIST_DISABLED, Constants.OBJECT_BRAND);

                    return string.Format(Constants.ERROR_NAME_EXIST, Constants.OBJECT_BRAND);
                }
            }

            return string.Empty;
        }
        #endregion
    }
}
