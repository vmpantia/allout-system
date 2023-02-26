using System;

namespace AllOut.Web.Blazor.Models
{
    public class SaveUserRequest : RequestBase
    {
        //User Information
        public User inputUser { get; set; }
    }
}
