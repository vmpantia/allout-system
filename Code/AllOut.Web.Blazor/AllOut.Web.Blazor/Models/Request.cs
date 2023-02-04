using System;

namespace AllOut.Web.Blazor.Models
{
    public class Request
    {
        public string RequestID { get; set; }
        public string FunctionID { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid RequestBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public Guid? ApprovedBy { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
