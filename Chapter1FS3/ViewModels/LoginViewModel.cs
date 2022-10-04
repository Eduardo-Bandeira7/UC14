using System.ComponentModel.DataAnnotations;

namespace Chapter1FS3.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Informe o E-mail do usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Informe a senha do usuário")]
        public string Senha { get; set; }
    }
}
