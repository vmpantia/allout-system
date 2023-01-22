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
    public class ProductService : IProductService
    {
        private readonly AllOutDbContext _db;
        private readonly IRequestService _request;
        private readonly IUtilityService _utility;
        public ProductService(AllOutDbContext context, IRequestService request, IUtilityService utility)
        {
            _db = context;
            _request = request;
            _utility = utility;
        }

        #region Public Methods
        public async Task<IEnumerable<ProductFullInformation>> GetProductsAsync()
        {
            //Initial Product Information
            var products = await (from a in _db.Products
                                  join b in _db.Brands on a.BrandID equals b.BrandID into bb
                                  from b in bb.DefaultIfEmpty()
                                  join c in _db.Categories on a.CategoryID equals c.CategoryID into cc
                                  from c in cc.DefaultIfEmpty()
                                  where a.Status != Constants.STATUS_DELETION_INT
                                  select new ProductFullInformation
                                  {
                                      ProductID = a.ProductID,
                                      ProductName = a.Name,
                                      ProductDescription = a.Description,
                                      ReorderPoint = a.ReorderPoint,
                                      Price = a.Price,
                                      Status = a.Status,
                                      CreatedDate = a.CreatedDate,
                                      ModifiedDate = a.ModifiedDate,
                                      BrandID = a.BrandID,
                                      BrandName = _utility.CheckBrandAvailablity(b) ? b.Name : Constants.NA,
                                      CategoryID = a.CategoryID,
                                      CategoryName = _utility.CheckCategoryAvailablity(c) ? c.Name : Constants.NA
                                  }).ToListAsync();

            foreach (var product in products)
            {
                await ParseOtherInformation(product);
            }

            return products;
        }

        public async Task<IEnumerable<ProductFullInformation>> GetProductsByQueryAsync(string query)
        {
            //Initial Product Information
            var products = await (from a in _db.Products
                                  join b in _db.Brands on a.BrandID equals b.BrandID into bb from b in bb.DefaultIfEmpty()
                                  join c in _db.Categories on a.CategoryID equals c.CategoryID into cc from c in cc.DefaultIfEmpty()
                                  where a.Status != Constants.STATUS_DELETION_INT &&
                                        (a.Name.Contains(query) || b.Name.Contains(query) ||c.Name.Contains(query))
                                  select new ProductFullInformation
                                  {
                                      ProductID = a.ProductID,
                                      ProductName = a.Name,
                                      ProductDescription = a.Description,
                                      ReorderPoint = a.ReorderPoint,
                                      Price = a.Price,
                                      Status = a.Status,
                                      CreatedDate = a.CreatedDate,
                                      ModifiedDate = a.ModifiedDate,
                                      BrandID = a.BrandID,
                                      BrandName = _utility.CheckBrandAvailablity(b) ? b.Name : Constants.NA,
                                      CategoryID = a.CategoryID,
                                      CategoryName = _utility.CheckCategoryAvailablity(c) ? c.Name : Constants.NA
                                  }).ToListAsync();

            foreach (var product in products)
            {
                await ParseOtherInformation(product);
            }

            return products;
        }

        public async Task<IEnumerable<ProductFullInformation>> GetProductsByStatusAsync(int status)
        {
            //Initial Product Information
            var products = await (from a in _db.Products
                                  join b in _db.Brands on a.BrandID equals b.BrandID into bb from b in bb.DefaultIfEmpty()
                                  join c in _db.Categories on a.CategoryID equals c.CategoryID into cc from c in cc.DefaultIfEmpty()
                                  where a.Status == status
                                  select new ProductFullInformation
                                  {
                                      ProductID = a.ProductID,
                                      ProductName = a.Name,
                                      ProductDescription = a.Description,
                                      ReorderPoint = a.ReorderPoint,
                                      Price = a.Price,
                                      Status = a.Status,
                                      CreatedDate = a.CreatedDate,
                                      ModifiedDate = a.ModifiedDate,
                                      BrandID = a.BrandID,
                                      BrandName = _utility.CheckBrandAvailablity(b) ? b.Name : Constants.NA,
                                      CategoryID = a.CategoryID,
                                      CategoryName = _utility.CheckCategoryAvailablity(c) ? c.Name : Constants.NA
                                  }).ToListAsync();

            foreach (var product in products)
            {
                await ParseOtherInformation(product);
            }

            return products;
        }

        public async Task<Product> GetProductByIDAsync(Guid productID)
        {
            var product = await _db.Products.FindAsync(productID);

            if (product == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND, Constants.OBJECT_PRODUCT));

            return product;
        }

        public async Task<int> GetCountProductsAsync()
        {
            var count = await _db.Products.Where(data => data.Status != Constants.STATUS_DELETION_INT).CountAsync();
            return count;
        }

        public async Task<int> GetCountProductsByStatusAsync(int status)
        {
            var count = await _db.Products.Where(data => data.Status == status).CountAsync();
            return count;
        }

        public async Task<string> SaveProductAsync(SaveProductRequest request)
        {
            //Check if Request is NULL
            if (request == null)
                throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_PRODUCT));

            var requestID = await _request.InsertRequest(_db, request.client.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new APIException(string.Format(Constants.ERROR_ID_NULL, Constants.OBJECT_PRODUCT));

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_PRODUCT_BY_ADMIN: //Add
                    await InsertProduct(request.inputProduct);
                    break;
                case Constants.FUNCTION_ID_CHANGE_PRODUCT_BY_ADMIN: //Change
                    await UpdateProduct(request.inputProduct);
                    break;
                case Constants.FUNCTION_ID_DELETE_PRODUCT_BY_ADMIN: //Delete
                    await DeleteProduct(request.inputProduct.ProductID);
                    break;
            }

            //Insert Transaction
            await InsertProduct_TRN(request.inputProduct, requestID.ToString());
            //Save Changes
            await _db.SaveChangesAsync();

            return requestID;
        }

        public async Task<string> UpdateProductStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            var requestID = await _request.InsertRequest(_db, request.client.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);
            var count = 0;
            foreach (var id in request.IDs)
            {
                count++;
                var product = await _db.Products.FindAsync(id);
                if (product != null)
                {
                    product.Status = request.newStatus;
                    product.ModifiedDate = DateTime.Now;
                    await InsertProduct_TRN(product, requestID.ToString(), count);
                }
            }

            await _db.SaveChangesAsync();

            return requestID;
        }
        #endregion

        #region Private Methods
        private async Task InsertProduct(Product inputProduct)
        {
            var errorMessage = await ValidateProduct(inputProduct);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new APIException(errorMessage);
            }

            inputProduct.ProductID = Guid.NewGuid();
            inputProduct.CreatedDate = DateTime.Now;
            await _db.Products.AddAsync(inputProduct);
        }

        private async Task UpdateProduct(Product inputProduct)
        {
            var currentProduct = await _db.Products.FindAsync(inputProduct.ProductID);

            if (currentProduct == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND_CHANGE, Constants.OBJECT_PRODUCT));

            var errorMessage = await ValidateProduct(inputProduct, currentProduct);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new APIException(errorMessage);
            }

            //currentProduct.ProductID = inputProduct.ProductID;
            currentProduct.BrandID = inputProduct.BrandID;
            currentProduct.CategoryID = inputProduct.CategoryID;
            currentProduct.Name = inputProduct.Name;
            currentProduct.Description = inputProduct.Description;
            currentProduct.ReorderPoint = inputProduct.ReorderPoint;
            currentProduct.Price = inputProduct.Price;
            currentProduct.Status = inputProduct.Status;
            //currentProduct.CreatedDate = inputProduct.CreatedDate;
            currentProduct.ModifiedDate = DateTime.Now;
        }

        private async Task DeleteProduct(Guid productID)
        {
            var currentProduct = await _db.Products.FindAsync(productID);

            if (currentProduct == null)
                throw new APIException(string.Format(Constants.ERROR_NOT_FOUND_DELETE, Constants.OBJECT_PRODUCT));

            _db.Products.Remove(currentProduct);
        }

        private async Task InsertProduct_TRN(Product inputProduct, string requestID, int number = 1)
        {
            var newTrn = new Product_TRN
            {
                RequestID = requestID,
                Number = number,
                ProductID = inputProduct.ProductID,
                BrandID = inputProduct.BrandID,
                CategoryID = inputProduct.CategoryID,
                Name = inputProduct.Name,
                Description = inputProduct.Description,
                ReorderPoint = inputProduct.ReorderPoint,
                Price = inputProduct.Price,
                Status = inputProduct.Status,
                CreatedDate = inputProduct.CreatedDate,
                ModifiedDate = inputProduct.ModifiedDate
            };

            await _db.Product_TRN.AddAsync(newTrn);
        }

        private async Task<string> ValidateProduct(Product newData, Product? oldData = null)
        {
            bool isNew = true;
            bool isNameChanged = false;

            //Check Data if NULL
            if (newData == null)
                return string.Format(Constants.ERROR_NULL, Constants.OBJECT_PRODUCT);

            //Validate Required Fields for Product
            //Check if Name have value
            if (string.IsNullOrEmpty(newData.Name))
                return string.Format(Constants.ERROR_NAME_REQUIRED, Constants.OBJECT_PRODUCT);

            //Check if BrandID have value
            if (newData.BrandID == Guid.Empty)
                return string.Format(Constants.ERROR_OBJECT_REQUIRED, Constants.OBJECT_BRAND);

            //Check if CategoryID have value
            if (newData.CategoryID == Guid.Empty)
                return string.Format(Constants.ERROR_OBJECT_REQUIRED, Constants.OBJECT_CATEGORY);

            if (oldData != null)
            {
                isNew = false;

                //Check if new data and old data changed
                if (newData.BrandID == oldData.BrandID &&
                    newData.CategoryID == oldData.CategoryID &&
                    newData.Name == oldData.Name &&
                    newData.Description == oldData.Description &&
                    newData.ReorderPoint == oldData.ReorderPoint &&
                    newData.Price == oldData.Price &&
                    newData.Status == oldData.Status &&
                    newData.CreatedDate == oldData.CreatedDate &&
                    newData.ModifiedDate == oldData.ModifiedDate)
                    return string.Format(Constants.ERROR_NO_CHANGES, Constants.OBJECT_PRODUCT);

                isNameChanged = newData.Name != oldData.Name;
            }

            if (isNew || isNameChanged)
            {
                //Check Duplicate Name for New Data
                var duplicate = await _db.Products.Where(data => data.Name == newData.Name).ToListAsync();

                if (duplicate.Count > 0)
                {
                    if (duplicate.First().Status != Constants.STATUS_ENABLED_INT)
                        return string.Format(Constants.ERROR_NAME_EXIST_DISABLED, Constants.OBJECT_PRODUCT);

                    return string.Format(Constants.ERROR_NAME_EXIST, Constants.OBJECT_PRODUCT);
                }
            }

            return string.Empty;
        }

        private async Task ParseOtherInformation(ProductFullInformation product)
        {
            var countInInventories = await _db.Inventories.Where(data => data.ProductID == product.ProductID &&
                                                                   data.Status == Constants.STATUS_ENABLED_INT)
                                                          .SumAsync(data => data.Quantity);

            var countInSales = await (from a in _db.Sales
                                      join b in _db.SalesItems on a.SalesID equals b.SalesID
                                      where a.Status == Constants.STATUS_ENABLED_INT &&
                                            b.ProductID == product.ProductID
                                      select b).SumAsync(data => data.Quantity);

            product.Stock = _utility.GetCurrentStock(countInInventories, countInSales);
            product.ReorderState = _utility.GetReorderState(product.Stock, product.ReorderPoint);
        }
        #endregion
    }
}
