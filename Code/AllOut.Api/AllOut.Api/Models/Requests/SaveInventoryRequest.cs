using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models.Requests
{
    public class SaveInventoryRequest : RequestBase
    {
        //Inventory Information
        public Inventory inputInventory { get; set; }
    }
}
