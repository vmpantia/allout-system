using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models.Requests
{
    public class SaveUserRequest : RequestBase
    {
        //User Information
        public User inputUser { get; set; }
    }
}
