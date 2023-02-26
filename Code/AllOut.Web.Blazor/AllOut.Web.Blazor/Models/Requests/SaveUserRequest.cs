using System;

namespace AllOut.Web.Blazor.Models.Requests
{
    public class SaveUserRequest : RequestBase
    {
        //User Information
        public User inputUser { get; set; }
    }
}
