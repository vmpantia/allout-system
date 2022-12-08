using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryByIDAsync(Guid CategoryID);
        Task<IEnumerable<Category>> GetCategorysAsync();
        Task<string> SaveCategoryAsync(SaveCategoryRequest request);
    }
}