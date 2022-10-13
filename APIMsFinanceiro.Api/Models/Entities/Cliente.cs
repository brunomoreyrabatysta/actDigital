using APIMsFinanceiro.API.Shared;

namespace APIMsFinanceiro.API.Models.Entities
{
    public class Cliente : Entity
    {        
        public string Nome { get; set; }

        public IList<Lancamento> Lancamentos { get; set; }
    }
}
