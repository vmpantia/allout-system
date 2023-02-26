using System;

namespace AllOut.Web.Blazor.Models.Requests
{
    public class SaveInventoryRequest : RequestBase
    {
        //Inventory Information
        public Inventory inputInventory { get; set; }
    }
}
