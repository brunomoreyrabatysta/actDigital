using System.ComponentModel.DataAnnotations;

namespace APIMsFinanceiro.API.ViewModels;

public class ClienteViewModel
{    
    [Required(ErrorMessage = "O nome é obrigatório!")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 40 caracteres!")]
    [Display(Name = "O nome do cliente!")]
    public string Nome { get; set; }
}
