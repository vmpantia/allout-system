using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllOut.Api.DataAccess.Models
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        public Guid BrandID { get; set; }
        public Guid CategoryID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        public int ReorderPoint { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
