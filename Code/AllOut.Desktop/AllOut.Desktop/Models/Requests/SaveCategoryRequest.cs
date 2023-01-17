using System;

namespace AllOut.Desktop.Models.Requests
{
    public class SaveCategoryRequest : RequestBase
    {
        //Category Information
        public Category inputCategory { get; set; }
    }
}
