using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace User_Management_API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }

    }
}
