using APIMsFinanceiro.API.Models.Entities;
using APIMsFinanceiro.API.ViewModels;
using APIMsFinanceiro.ViewModels;

namespace APIMsFinanceiro.API.Models.Repositories;

public interface ILancamentoRepository
{
    List<Lancamento> Get(int page, int pageSize);
    Lancamento GetBydId(int id);
    Lancamento Add(LancamentoViewModel lancamentoVM);
    Lancamento Update(int id, LancamentoViewModel lancamentoVM);
    Lancamento Delete(int id);
    int Count();
}
