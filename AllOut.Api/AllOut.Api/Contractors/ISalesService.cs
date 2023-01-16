using AllOut.Api.Models.Requests;

namespace AllOut.Api.Contractors
{
    public interface ISalesService
    {
        Task<string> SaveSalesAsync(SaveSalesRequest request);
    }
}