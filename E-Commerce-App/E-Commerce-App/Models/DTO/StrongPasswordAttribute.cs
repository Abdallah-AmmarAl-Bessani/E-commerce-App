using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace E_Commerce_App.Models.DTO
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string password)
            {
                // Define your password strength criteria here
                // For example, requiring at least 8 characters, including upper, lower, digit, and special characters
                var hasMinimumLength = password.Length >= 8;
                var hasUpperChar = new Regex(@"[A-Z]+").IsMatch(password);
                var hasLowerChar = new Regex(@"[a-z]+").IsMatch(password);
                var hasDigit = new Regex(@"[0-9]+").IsMatch(password);
                var hasSpecialChar = new Regex(@"[@!#$%^&*()_+{}\[\]:;<>,.?~\\-]+").IsMatch(password);

                return hasMinimumLength && hasUpperChar && hasLowerChar && hasDigit && hasSpecialChar;
            }

            return false;
        }
    }
}
