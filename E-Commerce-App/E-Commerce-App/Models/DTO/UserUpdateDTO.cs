using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Models.DTO
{
    public class UserUpdateDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
