using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models.Requests
{
    public class SaveBrandRequest : RequestBase
    {
        //Category Information
        public Brand inputBrand { get; set; }
    }
}
