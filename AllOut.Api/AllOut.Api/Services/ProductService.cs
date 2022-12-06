using AllOut.Api.Commons;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;

namespace AllOut.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly AllOutDbContext _db;
        private readonly IRequestService _request;
        public ProductService(AllOutDbContext context, IRequestService request)
        {
            _db = context;
            _request = request;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIDAsync(Guid productID)
        {
            var product = await _db.Products.FindAsync(productID);

            if (product == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_NOT_FOUND, Constants.OBJECT_PRODUCT));

            return product;
        }

        public async Task<string> SaveProductAsync(ProductRequest request)
        {
            //Check if Request is NULL
            if (request == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_REQUEST_NULL, Constants.OBJECT_PRODUCT));

            var requestID = await _request.InsertRequest(_db, request.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_ID_NULL, Constants.OBJECT_PRODUCT));

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_PRODUCT_BY_ADMIN: //Add Product
                    request.inputProduct.ProductID = Guid.NewGuid();
                    request.inputProduct.CreatedDate = Globals.EXEC_DATETIME;
                    await InsertProduct(request.inputProduct);
                    break;
                case Constants.FUNCTION_ID_CHANGE_PRODUCT_BY_ADMIN: //Change Product
                    request.inputProduct.ModifiedDate = Globals.EXEC_DATETIME;
                    await UpdateProduct(request.inputProduct);
                    break;
                default: //Delete Product
                    await DeleteProduct(request.inputProduct.ProductID);
                    break;
            }

            //Insert Transaction
            await InsertProduct_TRN(request.inputProduct, requestID.ToString());
            //Save Changes
            await _db.SaveChangesAsync();

            return requestID;
        }

        private async Task InsertProduct(Product inputProduct)
        {
            await _db.Products.AddAsync(inputProduct);
        }

        private async Task UpdateProduct(Product inputProduct)
        {
            var currentProduct = await _db.Products.FindAsync(inputProduct.ProductID);

            if (currentProduct == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_NOT_FOUND_CHANGE, Constants.OBJECT_PRODUCT));

            //currentProduct.ProductID = inputProduct.ProductID;
            currentProduct.BrandID = inputProduct.BrandID;
            currentProduct.CategoryID = inputProduct.CategoryID;
            currentProduct.Name = inputProduct.Name;
            currentProduct.Description = inputProduct.Description;
            currentProduct.ReorderPoint = inputProduct.ReorderPoint;
            currentProduct.Status = inputProduct.Status;
            //currentProduct.CreatedDate = inputProduct.CreatedDate;
            currentProduct.ModifiedDate = Globals.EXEC_DATETIME;
        }

        private async Task DeleteProduct(Guid productID)
        {
            var currentProduct = await _db.Products.FindAsync(productID);

            if (currentProduct == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_NOT_FOUND_DELETE, Constants.OBJECT_PRODUCT));

            _db.Remove(currentProduct);
        }

        private async Task InsertProduct_TRN(Product inputProduct, string requestID)
        {
            var newTrn = new Product_TRN
            {
                RequestID = requestID,
                ProductID = inputProduct.ProductID,
                BrandID = inputProduct.BrandID,
                CategoryID = inputProduct.CategoryID,
                Name = inputProduct.Name,
                Description = inputProduct.Description,
                ReorderPoint = inputProduct.ReorderPoint,
                Status = inputProduct.Status,
                CreatedDate = inputProduct.CreatedDate,
                ModifiedDate = inputProduct.ModifiedDate
            };

            await _db.Product_TRN.AddAsync(newTrn);
        }
    }
}
