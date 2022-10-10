using System.ComponentModel.DataAnnotations;

namespace APIMsFinanceiro.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O ClientId é obrigatório!")]
        [Display(Name = "ClientId para realizar a autentiacação!")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "A ClientSecret é obrigatória!")]
        [Display(Name = "ClientSecret para realizar a autentiacação!")]
        public string ClientSecret { get; set; }
    }
}
