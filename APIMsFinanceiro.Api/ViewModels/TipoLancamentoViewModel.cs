using System.ComponentModel.DataAnnotations;

namespace APIMsFinanceiro.ViewModels
{
    public class TipoLancamentoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="A descrição é obrigatória!")]
        [StringLength(40,MinimumLength =3, ErrorMessage = "A descrição deve conter entre 3 e 40 caracteres!")]
        [Display(Name = "A descrição do tipo de lançamento!")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "O tipo é obrigatório (Crédito | Débito | Nulo)!")]
        [Display(Name = "Tipo de lançamento (1 - Crédito | 2 - Débito | 3 - Nulo)!")]
        [Range(1, 3)]
        public int Tipo { get; set; }
    }
}
