using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    [PrimaryKey(nameof(SalesID), nameof(ChargeName))]
    public class OtherCharge
    {
        [Key, MaxLength(15)]
        public string SalesID { get; set; }
        [MaxLength(50)]
        public string ChargeName { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
    }
}
