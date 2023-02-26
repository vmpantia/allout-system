using System;

namespace AllOut.Web.Blazor.Models
{
    public class RequestBase
    {
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }
        public Client client { get; set; }
    }
}
