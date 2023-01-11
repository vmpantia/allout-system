namespace AllOut.Api.Models.Requests
{
    public class RequestBase
    {
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }
        public ClientInformation client { get; set; }
    }
}
