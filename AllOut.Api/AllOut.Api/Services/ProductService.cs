﻿using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;
using AllOut.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;

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

        public async Task<IEnumerable<ProductFullInformation>> GetProductsAsync()
        {
            var products = await (from p in _db.Products
                                  join b in _db.Brands on p.BrandID equals b.BrandID into bb from b in bb.DefaultIfEmpty()
                                  join c in _db.Categories on p.CategoryID equals c.CategoryID into cc from c in cc.DefaultIfEmpty()
                                  where p.Status == 0
                                  select new ProductFullInformation
                                  {
                                       productInfo = p,
                                       brandInfo = _utility.CheckBrandAvailablity(b) ? b : null,
                                       categoryInfo = _utility.CheckCategoryAvailablity(c) ? c : null
                                  }).ToListAsync();

            return products;
        }

        public async Task<IEnumerable<ProductFullInformation>> GetProductsByQueryAsync(string query)
        {
            var products = await (from p in _db.Products
                                  join b in _db.Brands on p.BrandID equals b.BrandID into bb
                                  from b in bb.DefaultIfEmpty()
                                  join c in _db.Categories on p.CategoryID equals c.CategoryID into cc
                                  from c in cc.DefaultIfEmpty()
                                  where p.Status == 0 &&
                                        (p.Name.Contains(query) || p.Description.Contains(query) ||
                                         b.Name.Contains(query) ||
                                         c.Name.Contains(query))
                                  select new ProductFullInformation
                                  {
                                      productInfo = p,
                                      brandInfo = _utility.CheckBrandAvailablity(b) ? b : null,
                                      categoryInfo = _utility.CheckCategoryAvailablity(c) ? c : null
                                  }).ToListAsync();

            return products;
        }

        public async Task<Product> GetProductByIDAsync(Guid productID)
        {
            var product = await _db.Products.FindAsync(productID);

            if (product == null)
                throw new ServiceException(string.Format(Constants.ERROR_NOT_FOUND, Constants.OBJECT_PRODUCT));

            return product;
        }

        public async Task<string> SaveProductAsync(SaveProductRequest request)
        {
            //Check if Request is NULL
            if (request == null)
                throw new ServiceException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_PRODUCT));

            var requestID = await _request.InsertRequest(_db, request.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new ServiceException(string.Format(Constants.ERROR_ID_NULL, Constants.OBJECT_PRODUCT));

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_PRODUCT_BY_ADMIN: //Add Product
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

        public async Task<string> UpdateProductStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            var requestID = await _request.InsertRequest(_db, request.UserID,
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

        private async Task InsertProduct(Product inputProduct)
        {
            var duplicate = await _db.Products.Where(data => data.Name == inputProduct.Name && 
                                                             data.BrandID == inputProduct.BrandID &&
                                                             data.CategoryID == inputProduct.CategoryID).ToListAsync();

            if (duplicate.Count > 0)
            {
                if (duplicate.First().Status != Constants.STATUS_ENABLED_INT)
                    throw new ServiceException(string.Format(Constants.ERROR_NAME_EXIST_DISABLED, Constants.OBJECT_PRODUCT));

                throw new ServiceException(string.Format(Constants.ERROR_NAME_EXIST, Constants.OBJECT_PRODUCT));
            }

            inputProduct.ProductID = Guid.NewGuid();
            inputProduct.CreatedDate = Globals.EXEC_DATETIME;
            await _db.Products.AddAsync(inputProduct);
        }

        private async Task UpdateProduct(Product inputProduct)
        {
            var currentProduct = await _db.Products.FindAsync(inputProduct.ProductID);

            if (currentProduct == null)
                throw new ServiceException(string.Format(Constants.ERROR_NOT_FOUND_CHANGE, Constants.OBJECT_PRODUCT));

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
                throw new ServiceException(string.Format(Constants.ERROR_NOT_FOUND_DELETE, Constants.OBJECT_PRODUCT));

            _db.Remove(currentProduct);
        }

        private async Task InsertProduct_TRN(Product inputProduct, string requestID, int number = 1)
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
