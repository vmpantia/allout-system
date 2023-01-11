using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models.Requests
{
    public class SaveProductRequest : RequestBase
    {
        //Product Information
        public Product inputProduct { get; set; }
    }
}
