﻿using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;

namespace AllOut.Api.Contractors
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<string> SaveProductAsync(ProductRequest request);
    }
}