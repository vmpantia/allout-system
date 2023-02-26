using System;

namespace AllOut.Web.Blazor.Models
{
    public class SaveProductRequest : RequestBase
    {
        //Product Information
        public Product inputProduct { get; set; }
    }
}
