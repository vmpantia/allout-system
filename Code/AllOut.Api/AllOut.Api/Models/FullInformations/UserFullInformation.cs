using AllOut.Api.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.Models.FullInformations
{
    public class UserFullInformation : User
    {
        public string RoleName { get; set; }
    }
}
