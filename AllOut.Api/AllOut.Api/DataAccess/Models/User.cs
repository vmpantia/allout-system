﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string MiddleName { get; set; }
        [Required, MaxLength(25)]
        public string LastName { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public int Permission { get; set; }
        public int Status { get; set; } 
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}