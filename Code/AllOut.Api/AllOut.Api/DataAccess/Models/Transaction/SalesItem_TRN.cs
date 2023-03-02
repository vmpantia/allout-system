using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models.Transactions
{
    [PrimaryKey(nameof(RequestID), nameof(Number))]
    public class SalesItem_TRN
    {
        [MaxLength(15)]
        public string RequestID { get; set; }
        public int Number { get; set; }
        [MaxLength(15)]
        public string SalesID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        [Precision(18, 2)]
        public decimal Total { get; set; }
    }
}
