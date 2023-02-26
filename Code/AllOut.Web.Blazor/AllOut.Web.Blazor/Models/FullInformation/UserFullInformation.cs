using System;

namespace AllOut.Web.Blazor.Models
{
    public class UserFullInformation
    {
        public Guid UserID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
