using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;

namespace AllOut.Api.Contractors
{
    public interface IBrandService
    {
        Task<Brand> GetBrandByIDAsync(Guid BrandID);
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<string> SaveBrandAsync(BrandRequest request);
    }
}