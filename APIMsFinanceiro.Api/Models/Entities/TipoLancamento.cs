using APIMsFinanceiro.API.Enums;
using APIMsFinanceiro.API.Shared;

namespace APIMsFinanceiro.API.Models.Entities
{
    public class TipoLancamento : Entity
    {
        public string Descricao { get; set; }
        public ETipoLancamento Tipo { get; set; }

        public IList<Lancamento> Lancamentos { get; set; }
    }
}
