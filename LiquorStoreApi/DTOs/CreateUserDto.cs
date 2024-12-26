using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Please add First Name!")]
        [MinLength(2, ErrorMessage = "First name must contain at least 2 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please add Last Name!")]
        [MinLength(2, ErrorMessage = "Last name must contain at least 2 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="You must enter email address.")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter password")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-]).{6,}$", ErrorMessage ="Password must must be at least 6 characters and contain at least 1 lowercase, 1 uppercase, 1 number and 1 special character!")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please confirm your password!")]
        public string ConfirmPassword { get; set; }
    }
}
