using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    public class Sales
    {
        [Key, MaxLength(15)]
        public string SalesID { get; set; }
        public Guid UserID { get; set; }
        [Precision(18, 2)]
        public decimal AmountPaid { get; set; }
        [Precision(18, 2)]
        public decimal Change { get; set; }
        [MaxLength(100)]
        public string? Remarks { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
