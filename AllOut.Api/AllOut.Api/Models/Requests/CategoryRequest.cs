using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models.Requests
{
    public class CategoryRequest
    {
        //Request Information
        public Guid UserID { get; set; }
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }

        //Category Information
        public Category inputCategory { get; set; }
    }
}
