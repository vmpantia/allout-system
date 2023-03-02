﻿using AllOut.Web.Blazor.Models.DataAccess;

namespace AllOut.Web.Blazor.Models.FullInformations
{
    public class ProductFullInformation : Product
    {
        public string Brand { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public bool ReorderState { get; set; }
    }
}
