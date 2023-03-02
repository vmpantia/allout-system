using AllOut.Web.Blazor.Models.DataAccess;

namespace AllOut.Web.Blazor.Models.FullInformations
{
    public class InventoryFullInformation : Inventory
    {
        public string ProductName { get; set; }
        public Guid BrandID { get; set; }
        public string BrandName { get; set; }
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
