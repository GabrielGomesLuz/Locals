using System.ComponentModel.DataAnnotations;

namespace Locals.ViewModels
{
    public class LoginViewModel
    {


        [Required(ErrorMessage ="Necessário informar o nome")]
        [Display(Name ="Usuário")]

        public string UserName { get; set; }


        [Required(ErrorMessage = "Necessário informar a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
