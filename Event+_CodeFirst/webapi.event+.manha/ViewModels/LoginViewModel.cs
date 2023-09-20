using System.ComponentModel.DataAnnotations;

namespace webapi.event_.manha.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatorio")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatoria")]
        public string? Senha { get; set; }
    }
}
