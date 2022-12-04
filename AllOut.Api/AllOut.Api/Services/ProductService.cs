using AllOut.Api.Commons;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;
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
                throw new ServiceException(Constants.ERROR_PRODUCT_NOT_FOUND);

            return product;
        }

        public async Task<string> SaveProductAsync(ProductRequest request)
        {
            //Check if Request is NULL
            if (request == null)
                throw new ServiceException(Constants.ERROR_PRODUCT_REQUEST_NULL);

            var requestID = await _request.InsertRequest(_db, request.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new ServiceException(Constants.ERROR_REQUEST_ID_NULL);

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_PRODUCT_BY_ADMIN: //Add Product
                    request.inputProduct.ProductID = Guid.NewGuid();
                    await InsertProduct(request.inputProduct);
                    break;
                case Constants.FUNCTION_ID_CHANGE_PRODUCT_BY_ADMIN: //Change Product
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
                throw new ServiceException(Constants.ERROR_PRODUCT_NOT_FOUND_CHANGE);

            //currentProduct.ProductID = inputProduct.ProductID;
            currentProduct.CategoryID = inputProduct.CategoryID;
            currentProduct.Name = inputProduct.Name;
            currentProduct.Description = inputProduct.Description;
            currentProduct.Status = inputProduct.Status;
            //currentProduct.CreatedDate = inputProduct.CreatedDate;
            currentProduct.ModifiedDate = Globals.EXEC_DATETIME;
        }

        private async Task DeleteProduct(Guid productID)
        {
            var currentProduct = await _db.Products.FindAsync(productID);

            if (currentProduct == null)
                throw new ServiceException(Constants.ERROR_PRODUCT_NOT_FOUND_DELETE);

            _db.Remove(currentProduct);
        }

        private async Task InsertProduct_TRN(Product inputProduct, string requestID)
        {
            var newTrn = new Product_TRN
            {
                RequestID = requestID,
                ProductID = inputProduct.ProductID,
                CategoryID = inputProduct.CategoryID,
                Name = inputProduct.Name,
                Description = inputProduct.Description,
                Status = inputProduct.Status,
                CreatedDate = inputProduct.CreatedDate,
                ModifiedDate = inputProduct.ModifiedDate
            };

            await _db.Product_TRN.AddAsync(newTrn);
        }
    }
}
