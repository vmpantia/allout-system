namespace AllOut.Api.Models.Requests
{
    public class LoginUserRequest : RequestBase
    {
        public string LogonName { get; set; }
        public string Password { get; set; }
    }
}
