using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    public class Sales
    {
        [Key]
        public Guid SalesID { get; set; }
        public Guid UserID { get; set; }
        [Required, MaxLength(100)]
        public string Remarks { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
