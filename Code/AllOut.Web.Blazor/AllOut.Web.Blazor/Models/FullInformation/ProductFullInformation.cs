using System;

namespace AllOut.Web.Blazor.Models
{
    public class ProductFullInformation : Product
    {
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public int Stock { get; set; }
        public bool ReorderState { get; set; }
    }
}
