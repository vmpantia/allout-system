using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models.FullInformations
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
