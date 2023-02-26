using AllOut.Web.Blazor.Models;

namespace AllOut.Web.Blazor.Contractors
{
    public interface IHTTPService
    {
        Task<Response> GetRequestAsync(string url, Guid clientID, object? param = null);
        Task<Response> PostRequestAsync(string url, object request);
    }
}