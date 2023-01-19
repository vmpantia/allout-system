using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<IEnumerable<Brand>> GetBrandsByQueryAsync(string query);
        Task<IEnumerable<Brand>> GetBrandsByStatusAsync(int status);
        Task<Brand> GetBrandByIDAsync(Guid BrandID);
        Task<int> GetCountBrandsAsync();
        Task<int> GetCountBrandsByStatusAsync(int status);
        Task<string> SaveBrandAsync(SaveBrandRequest request);
        Task<string> UpdateBrandStatusByIDsAsync(UpdateStatusByIDsRequest request);
    }
}