using AllOut.Web.Blazor.Models.DataAccess;

namespace AllOut.Web.Blazor.Models.FullInformations
{
    public class UserFullInformation : User
    {
        public string Name { 
            get {
                return LastName + ", " + FirstName;
            }
        }
        public string RoleName { get; set; }
    }
}
