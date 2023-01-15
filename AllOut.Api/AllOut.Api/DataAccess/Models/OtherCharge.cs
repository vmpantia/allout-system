using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    public class OtherCharge
    {
        [Key]
        public Guid SalesID { get; set; }
        [Required, MaxLength(50)]
        public string ChargeName { get; set; }
        public decimal Amount { get; set; }
    }
}
