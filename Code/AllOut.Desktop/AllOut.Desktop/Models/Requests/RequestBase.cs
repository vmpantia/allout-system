using System;

namespace AllOut.Desktop.Models.Requests
{
    public class RequestBase
    {
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }
        public Client client { get; set; }
    }
}
