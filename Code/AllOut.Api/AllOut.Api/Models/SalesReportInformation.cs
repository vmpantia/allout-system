using AllOut.Api.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.Models
{
    public class SalesReportInformation
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
