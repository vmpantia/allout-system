using System;

namespace AllOut.Web.Blazor.Models.Requests
{
    public class SaveBrandRequest : RequestBase
    {
        //Category Information
        public Brand inputBrand { get; set; }
    }
}
