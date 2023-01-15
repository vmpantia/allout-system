using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    [PrimaryKey(nameof(RequestID), nameof(Number), nameof(CategoryID))]
    public class Category_TRN
    {
        [MaxLength(12)]
        public string RequestID { get; set; }
        public int Number { get; set; }
        public Guid CategoryID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
