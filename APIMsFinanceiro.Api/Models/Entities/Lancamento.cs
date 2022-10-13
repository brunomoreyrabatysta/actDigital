using APIMsFinanceiro.API.Shared;

namespace APIMsFinanceiro.API.Models.Entities;

public class Lancamento : Entity
{    
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public double Valor { get; set; }
    public TipoLancamento TipoLancamento { get; set; }
    public Cliente Cliente { get; set; }
}
