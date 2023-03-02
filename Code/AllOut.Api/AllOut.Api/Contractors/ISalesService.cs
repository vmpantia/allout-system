using AllOut.Api.Models.FullInformations;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesFullInformation>> GetSalesAsync();
        Task<IEnumerable<SalesFullInformation>> GetSalesByQueryAsync(string query);
        Task<IEnumerable<SalesFullInformation>> GetSalesByStatusAsync(int status);
        Task<SalesFullInformation> GetSalesByIDAsync(string id);
        Task<int> GetCountSalesAsync();
        Task<int> GetCountSalesByStatusAsync(int status);
        Task<string> SaveSalesAsync(SaveSalesRequest request);
        Task<string> UpdateSalesStatusByIDsAsync(UpdateStatusByStringIDsRequest request);
    }
}