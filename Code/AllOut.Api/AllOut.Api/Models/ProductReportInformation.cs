using AllOut.Api.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.Models
{
    public class ProductReportInformation
    {
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
