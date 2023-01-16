using AllOut.Api.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.Models
{
    public class ProductFullInformation
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int ReorderPoint { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid BrandID { get; set; }
        public string BrandName { get; set; }
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int Stock { get; set; }
        public bool ReorderState { get; set; }  
    }
}
