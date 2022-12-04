﻿using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models
{
    public class InventoryRequest
    {
        //Request Information
        public Guid UserID { get; set; }
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }

        //Inventory Information
        public Inventory inputInventory { get; set; }
    }
}
