using System;

namespace AllOut.Desktop.Models.Requests
{
    public class SaveUserRequest : RequestBase
    {
        //User Information
        public User inputUser { get; set; }
    }
}
