using System;

namespace AllOut.Desktop.Models.Requests
{
    public class SaveProductRequest : RequestBase
    {
        //Product Information
        public Product inputProduct { get; set; }
    }
}
