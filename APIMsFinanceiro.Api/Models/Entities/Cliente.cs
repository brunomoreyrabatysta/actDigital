namespace APIMsFinanceiro.API.Models.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IList<Lancamento>? Lancamentos { get; set; }
    }
}
