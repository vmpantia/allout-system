using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.FullInformations;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface IProductService
    {
        Task<IEnumerable<ProductFullInformation>> GetProductsAsync();
        Task<IEnumerable<ProductFullInformation>> GetProductsByQueryAsync(string query);
        Task<IEnumerable<ProductFullInformation>> GetProductsByStatusAsync(int status);
        Task<Product> GetProductByIDAsync(Guid productID);
        Task<int> GetCountProductsAsync();
        Task<int> GetCountProductsByStatusAsync(int status);
        Task<string> SaveProductAsync(SaveProductRequest request);
        Task<string> UpdateProductStatusByIDsAsync(UpdateStatusByGUIDsRequest request);
    }
}