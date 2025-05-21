using System.ComponentModel.DataAnnotations;

namespace TstRedeLius.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme o password")]
        [Compare("Password", ErrorMessage = "Passwords não corresponde")]
        public string ConfirmPassword { get; set; }
    }
}
