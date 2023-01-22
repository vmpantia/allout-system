using AllOut.Api.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesReportInformation>> GetSalesReportByYearAsync();
        Task<IEnumerable<SalesReportInformation>> GetSalesReportByMonthAsync(int year);
        Task<IEnumerable<SalesFullInformation>> GetSales();
        Task<IEnumerable<SalesFullInformation>> GetSalesByQuery(string query);
        Task<IEnumerable<SalesFullInformation>> GetSalesByID(string id);
        Task<string> SaveSalesAsync(SaveSalesRequest request);

    }
}