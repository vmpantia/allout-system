using AllOut.Api.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.Models
{
    public class SalesItemFullInformation
    {
        public string SalesID { get; set; }
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
