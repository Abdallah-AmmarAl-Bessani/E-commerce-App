using System.ComponentModel.DataAnnotations;


namespace E_Commerce_App.Models.DTO
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [StrongPassword(ErrorMessage = "Password must be strong (at least 8 characters, including upper, lower, digit, and special characters).")]
        public string Password { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid email format.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^(\d{10}|\d{12})$", ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        public string? Roles { get; set; } // You may need additional validation for roles if necessary

    }
}
