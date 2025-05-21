using System.ComponentModel.DataAnnotations;

namespace TstRedeLius.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email deve ser informado!")]
        [EmailAddress(ErrorMessage = "Formato inválido de email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password deve ser informado.")]
        [StringLength(20, ErrorMessage = "O {0} deve ter ao menos {2} e no máximo " +
            "{1} caracteres.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
