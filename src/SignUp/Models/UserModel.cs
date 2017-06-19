namespace SignUp.Models
{
    using BCrypt.Net;
    using System.ComponentModel.DataAnnotations;

    public class UserModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter an email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter a password")]
        [StringLength(32, MinimumLength = 10, ErrorMessage = "Please enter a password with a length between {2} and {1} characters")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        public void HashPassword()
        {
            Password = BCrypt.HashPassword(Password);
        }
    }
}
