using System;

namespace AllOut.Desktop.Models.Requests
{
    public class SaveInventoryRequest : RequestBase
    {
        //Inventory Information
        public Inventory inputInventory { get; set; }
    }
}
