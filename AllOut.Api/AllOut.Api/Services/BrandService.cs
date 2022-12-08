using AllOut.Api.Commons;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
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

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _db.Brands.ToListAsync();
        }

        public async Task<IEnumerable<Brand>> GetBrandsByQueryAsync(string query)
        {
            var brands = await _db.Brands.Where(data => data.Name.Contains(query) || data.Description.Contains(query)).ToListAsync();

            return brands;
        }

        public async Task<Brand> GetBrandByIDAsync(Guid BrandID)
        {
            var brand = await _db.Brands.FindAsync(BrandID);

            if (brand == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_NOT_FOUND, Constants.OBJECT_BRAND));

            return brand;
        }

        public async Task<string> SaveBrandAsync(SaveBrandRequest request)
        {
            var requestID = await _request.InsertRequest(_db, request.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_ID_NULL, Constants.OBJECT_BRAND));

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_BRAND_BY_ADMIN: //Add Brand
                    await InsertBrand(request.inputBrand);
                    break;
                case Constants.FUNCTION_ID_CHANGE_BRAND_BY_ADMIN: //Change Brand
                    await UpdateBrand(request.inputBrand);
                    break;
                default: //Delete Brand
                    await DeleteBrand(request.inputBrand.BrandID);
                    break;
            }

            //Insert Transaction
            await InsertBrand_TRN(request.inputBrand, requestID.ToString());
            //Save Changes
            await _db.SaveChangesAsync();

            return requestID;
        }

        public async Task<string> UpdateStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            var requestID = await _request.InsertRequest(_db, request.UserID,
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


        private async Task InsertBrand(Brand inputBrand)
        {
            var duplicate = await _db.Brands.Where(data => data.Name == inputBrand.Name).ToListAsync();

            if (duplicate.Count > 0)
            {
                if (duplicate.First().Status != Constants.INT_STATUS_ENABLED)
                    throw new ServiceException(string.Format(Constants.ERROR_OBJECT_NAME_EXIST_DISABLED, Constants.OBJECT_BRAND));

                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_NAME_EXIST, Constants.OBJECT_BRAND));
            }

            inputBrand.BrandID = Guid.NewGuid();
            inputBrand.CreatedDate = Globals.EXEC_DATETIME;
            await _db.Brands.AddAsync(inputBrand);
        }

        private async Task UpdateBrand(Brand inputBrand)
        {
            var currentBrand = await _db.Brands.FindAsync(inputBrand.BrandID);

            if (currentBrand == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_NOT_FOUND_CHANGE, Constants.OBJECT_BRAND));

            //currentBrand.BrandID = inputBrand.BrandID;
            currentBrand.Name = inputBrand.Name;
            currentBrand.Description = inputBrand.Description;
            currentBrand.Status = inputBrand.Status;
            //currentBrand.CreatedDate = inputBrand.CreatedDate;
            currentBrand.ModifiedDate = Globals.EXEC_DATETIME;
        }

        private async Task DeleteBrand(Guid BrandID)
        {
            var currentBrand = await _db.Categories.FindAsync(BrandID);

            if (currentBrand == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_NOT_FOUND_DELETE, Constants.OBJECT_BRAND));

            _db.Remove(currentBrand);
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
    }
}
