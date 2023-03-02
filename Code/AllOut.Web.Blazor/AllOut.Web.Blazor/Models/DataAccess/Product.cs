using AllOut.Web.Blazor.Models.Commons;

namespace AllOut.Web.Blazor.Models.DataAccess
{
    public class Product : Selection
    {
        public Guid ProductID { get; set; }
        public Guid BrandID { get; set; }
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReorderPoint { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
