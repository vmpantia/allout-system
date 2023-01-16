using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models.Requests
{
    public class RequestBase
    {
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }
        public Client client { get; set; }
    }
}
