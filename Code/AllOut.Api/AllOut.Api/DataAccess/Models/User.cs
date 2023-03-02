using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(60)]
        public string Username { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string? MiddleName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public Guid RoleID { get; set; }
        public int Status { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
