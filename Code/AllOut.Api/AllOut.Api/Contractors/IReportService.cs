using AllOut.Api.Models;

namespace AllOut.Api.Contractors
{
    public interface IReportService
    {
        Task<IEnumerable<SalesReportInformation>> GetSalesReportAsync();
        Task<IEnumerable<SalesReportInformation>> GetSalesReportByYearAsync(int year);
        Task<IEnumerable<SalesReportInformation>> GetSalesReportByYearAndMonthAsync(string query);
    }
}