using AllOut.Api.Models;
using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesReportInformation>> GetSalesReportByYearAsync();
        Task<IEnumerable<SalesReportInformation>> GetSalesReportByMonthAsync(int year);
        Task<string> SaveSalesAsync(SaveSalesRequest request);

    }
}