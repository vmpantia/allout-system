using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    public class Brand_TRN
    {
        [Key, MaxLength(12)]
        public string RequestID { get; set; }
        public Guid BrandID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } 
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
