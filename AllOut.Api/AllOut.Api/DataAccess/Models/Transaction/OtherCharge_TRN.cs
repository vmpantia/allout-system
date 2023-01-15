using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    [PrimaryKey(nameof(RequestID), nameof(Number), nameof(SalesID))]
    public class OtherCharge_TRN
    {
        [MaxLength(15)]
        public string RequestID { get; set; }
        public int Number { get; set; }
        [MaxLength(15)]
        public string SalesID { get; set; }
        [Required, MaxLength(50)]
        public string ChargeName { get; set; }
        public decimal Amount { get; set; }
    }
}
