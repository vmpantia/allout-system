﻿using AllOut.Web.Blazor.Models.DataAccess;

namespace AllOut.Web.Blazor.Models.Requests
{
    public class SaveCategoryRequest : RequestBase
    {
        //Category Information
        public Category inputCategory { get; set; }
    }
}
