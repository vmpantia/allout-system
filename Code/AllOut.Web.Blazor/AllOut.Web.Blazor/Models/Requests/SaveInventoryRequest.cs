using System;

namespace AllOut.Web.Blazor.Models
{
    public class SaveInventoryRequest : RequestBase
    {
        //Inventory Information
        public Inventory inputInventory { get; set; }
    }
}
