﻿using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;

namespace AllOut.Api.Contractors
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryByIDAsync(Guid CategoryID);
        Task<IEnumerable<Category>> GetCategorysAsync();
        Task<string> SaveCategoryAsync(CategoryRequest request);
    }
}