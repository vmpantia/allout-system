using System;

namespace AllOut.Desktop.Models.Requests
{
    public class SaveBrandRequest : RequestBase
    {
        //Category Information
        public Brand inputBrand { get; set; }
    }
}
