using AllOut.Web.Blazor.Models;
using AllOut.Web.Blazor.Models.Requests;

namespace AllOut.Web.Blazor.Contractors
{
    public interface IHTTPService
    {
        Task<Response> GetRequestAsync(string url, Guid clientID, object? param = null);
        Task<Response> PostRequestAsync(string url, object request);
    }
}