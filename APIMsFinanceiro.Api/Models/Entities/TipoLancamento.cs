using APIMsFinanceiro.API.Enums;

namespace APIMsFinanceiro.API.Models.Entities
{
    public class TipoLancamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ETipoLancamento Tipo { get; set; }

        public IList<Lancamento> Lancamentos { get; set; }
    }
}
