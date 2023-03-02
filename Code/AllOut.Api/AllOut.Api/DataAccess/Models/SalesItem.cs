using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    [PrimaryKey(nameof(SalesID), nameof(ProductID))]
    public class SalesItem
    {
        [Key, MaxLength(15)]
        public string SalesID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        [Precision(18, 2)]
        public decimal Total { get; set; }
    }
}
