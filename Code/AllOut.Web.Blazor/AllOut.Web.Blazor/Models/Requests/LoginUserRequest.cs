namespace AllOut.Web.Blazor.Models.Requests
{
    public class LoginUserRequest
    {
        public string LogonName { get; set; }
        public string Password { get; set; }

        //Computer Details
        public string Browser { get; set; }
        public string IPAddress { get; set; }
        public string WindowsVersion { get; set; }
    }
}
