using AllOut.Web.Blazor.Models.DataAccess;

namespace AllOut.Web.Blazor.Models.Requests
{
    public class SaveBrandRequest : RequestBase
    {
        //Category Information
        public Brand inputBrand { get; set; }
    }
}
