using System;

namespace AllOut.Web.Blazor.Models
{
    public class SaveCategoryRequest : RequestBase
    {
        //Category Information
        public Category inputCategory { get; set; }
    }
}
