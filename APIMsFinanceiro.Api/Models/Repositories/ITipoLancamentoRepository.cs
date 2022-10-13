using APIMsFinanceiro.API.Models.Entities;
using APIMsFinanceiro.ViewModels;

namespace APIMsFinanceiro.API.Models.Repositories;

public interface ITipoLancamentoRepository
{
    ResultViewModel<dynamic> Get(int page, int pageSize);
    ResultViewModel<TipoLancamento> GetBydId(int id);
    ResultViewModel<TipoLancamento> Add(TipoLancamentoViewModel tipoLancamento);
    ResultViewModel<TipoLancamento> Update(int id, TipoLancamentoViewModel tipoLancamento);
    ResultViewModel<TipoLancamento> Delete(int id);
    int Count();
}
