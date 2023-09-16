using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace E_Commerce_App.Models.DTO
{
    public class LogInDTO
    {

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StrongPassword(ErrorMessage = "Password must be strong (at least 8 characters, including upper, lower, digit, and special characters).")]
        public string Password { get; set; }
    }
}
