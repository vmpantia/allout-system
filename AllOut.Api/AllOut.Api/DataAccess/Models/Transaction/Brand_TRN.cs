using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    [PrimaryKey(nameof(RequestID), nameof(Number))]
    public class Brand_TRN
    {
        [MaxLength(12)]
        public string RequestID { get; set; }
        public int Number { get; set; }
        public Guid BrandID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } 
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
