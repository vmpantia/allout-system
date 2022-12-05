using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models
{
    public class BrandRequest
    {
        //Request Information
        public Guid UserID { get; set; }
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }

        //Category Information
        public Brand inputBrand { get; set; }
    }
}
