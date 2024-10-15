﻿using System.ComponentModel.DataAnnotations;

namespace Pratik_Jwt.Data
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
