using AllOut.Api.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesReportInformation>> GetSalesReportByYearAsync();
        Task<IEnumerable<SalesReportInformation>> GetSalesReportByMonthAsync(int year);
        Task<IEnumerable<SalesFullInformation>> GetSalesAsync();
        Task<IEnumerable<SalesFullInformation>> GetSalesByQueryAsync(string query);
        Task<IEnumerable<SalesFullInformation>> GetSalesByIDAsync(string id);
        Task<string> SaveSalesAsync(SaveSalesRequest request);

    }
}