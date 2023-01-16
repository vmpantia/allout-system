using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface IProductService
    {
        Task<IEnumerable<ProductFullInformation>> GetProductsAsync();
        Task<IEnumerable<ProductFullInformation>> GetProductsByQueryAsync(string query);
        Task<Product> GetProductByIDAsync(Guid productID);
        Task<string> SaveProductAsync(SaveProductRequest request);
        Task<string> UpdateProductStatusByIDsAsync(UpdateStatusByIDsRequest request);
    }
}