using APIMsFinanceiro.API.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APIMsFinanceiro.API.ViewModels;

public class LancamentoViewModel
{
    [Required(ErrorMessage = "A descrição é obrigatória!")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "A descrição deve conter entre 3 e 40 caracteres!")]
    [Display(Name = "A descrição do lançamento!")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "A data do lançamento é obrigatória!")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "yyyy/mm/dd")]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "O valor do lançamento é obrigatório!")]
    public double Valor { get; set; }

    [Required(ErrorMessage = "O tipo do lançamento é obrigatório!")]
    public int TipoLancamentoId { get; set; }

    [Required(ErrorMessage = "O cliente é obrigatório!")]
    public int ClienteId { get; set; }
}
