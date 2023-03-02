using System;
using AllOut.Web.Blazor.Models.Data;

namespace AllOut.Web.Blazor.Models
{
    public class SaveUserRequest : RequestBase
    {
        //User Information
        public User inputUser { get; set; }
    }
}
