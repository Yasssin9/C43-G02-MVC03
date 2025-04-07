using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{6,}$",
        ErrorMessage = "Password must be at least 6 characters and include uppercase, lowercase, number, and special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password Does Not Match Password")]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
