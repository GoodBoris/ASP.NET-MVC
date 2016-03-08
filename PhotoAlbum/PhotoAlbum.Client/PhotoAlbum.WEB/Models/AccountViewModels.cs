using System.ComponentModel.DataAnnotations;

namespace PhotoAlbum.WEB.Models
{

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
    
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Login")]
        [RegularExpression(@"^[a-zA-Z0-9_-]{6,18}$", 
            ErrorMessage = "Username can contains letter, digit, capital letter, - and _. Length from 6 to 18")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,32}$",
            ErrorMessage = "Password must contains letter, digit, capital letter. Minimum length: 6")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

}
