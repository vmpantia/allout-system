using AllOut.Api.Models;

namespace AllOut.Api.Contractors
{
    public interface IReportService
    {
        Task<IEnumerable<SalesReportInformation>> GetSalesReportAsync();
        Task<IEnumerable<SalesReportInformation>> GetSalesReportByYearAsync(int year);
        Task<IEnumerable<SalesReportInformation>> GetSalesReportByYearAndMonthAsync(string query);
        Task<IEnumerable<ProductReportInformation>> GetProductsReportAsync();
        Task<IEnumerable<ProductReportInformation>> GetProductsReportByYearAsync(int year);
        Task<IEnumerable<ProductReportInformation>> GetProductsReportByYearAndMonthAsync(string query);
    }
}