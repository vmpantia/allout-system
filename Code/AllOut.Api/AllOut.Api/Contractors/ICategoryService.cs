using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesByQueryAsync(string query);
        Task<IEnumerable<Category>> GetCategoriesByStatusAsync(int status);
        Task<Category> GetCategoryByIDAsync(Guid CategoryID);
        Task<int> GetCountCategoriesAsync();
        Task<int> GetCountCategoriesByStatusAsync(int status);
        Task<string> SaveCategoryAsync(SaveCategoryRequest request);
        Task<string> UpdateCategoryStatusByIDsAsync(UpdateStatusByIDsRequest request);
    }
}