using AllOut.Api.Commons;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;
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

        public async Task<Brand> GetBrandByIDAsync(Guid BrandID)
        {
            var brand = await _db.Brands.FindAsync(BrandID);

            if (brand == null)
                throw new ServiceException(String.Format(Constants.ERROR_OBJECT_NOT_FOUND, Constants.OBJECT_BRAND));

            return brand;
        }

        public async Task<string> SaveBrandAsync(BrandRequest request)
        {
            //Check if Request is NULL
            if (request == null)
                throw new ServiceException(String.Format(Constants.ERROR_OBJECT_REQUEST_NULL, Constants.OBJECT_BRAND));

            var requestID = await _request.InsertRequest(_db, request.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new ServiceException(String.Format(Constants.ERROR_OBJECT_ID_NULL, Constants.OBJECT_BRAND));

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_BRAND_BY_ADMIN: //Add Brand
                    request.inputBrand.BrandID = Guid.NewGuid();
                    request.inputBrand.CreatedDate = Globals.EXEC_DATETIME;
                    await InsertBrand(request.inputBrand);
                    break;
                case Constants.FUNCTION_ID_CHANGE_BRAND_BY_ADMIN: //Change Brand
                    request.inputBrand.ModifiedDate = Globals.EXEC_DATETIME;
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

        private async Task InsertBrand(Brand inputBrand)
        {
            await _db.Brands.AddAsync(inputBrand);
        }

        private async Task UpdateBrand(Brand inputBrand)
        {
            var currentBrand = await _db.Brands.FindAsync(inputBrand.BrandID);

            if (currentBrand == null)
                throw new ServiceException(String.Format(Constants.ERROR_OBJECT_NOT_FOUND_CHANGE, Constants.OBJECT_BRAND));

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
                throw new ServiceException(String.Format(Constants.ERROR_OBJECT_NOT_FOUND_DELETE, Constants.OBJECT_BRAND));

            _db.Remove(currentBrand);
        }

        private async Task InsertBrand_TRN(Brand inputBrand, string requestID)
        {
            var newTrn = new Brand_TRN
            {
                RequestID = requestID,
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
