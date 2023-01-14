using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    public class Sales
    {
        [Key]
        public Guid SalesID { get; set; }
        public Guid UserID { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
