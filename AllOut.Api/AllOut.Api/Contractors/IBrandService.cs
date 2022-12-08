using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetBrandsByQueryAsync(string query);
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<Brand> GetBrandByIDAsync(Guid BrandID);
        Task<string> SaveBrandAsync(SaveBrandRequest request);
        Task<string> UpdateBrandStatusByIDsAsync(UpdateStatusByIDsRequest request);
    }
}