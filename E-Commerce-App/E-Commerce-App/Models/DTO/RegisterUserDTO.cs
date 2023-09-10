using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Models.DTO
{
    public class RegisterUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        
        public string? Roles { get; set; }
    }
}
