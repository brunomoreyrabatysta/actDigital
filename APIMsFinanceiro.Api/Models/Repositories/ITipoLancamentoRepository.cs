using APIMsFinanceiro.API.Models.Entities;
using APIMsFinanceiro.ViewModels;

namespace APIMsFinanceiro.API.Models.Repositories;

public interface ITipoLancamentoRepository
{
    List<TipoLancamento> Get(int page, int pageSize);
    TipoLancamento GetBydId(int id);
    TipoLancamento Add(TipoLancamentoViewModel tipoLancamento);
    TipoLancamento Update(int id, TipoLancamentoViewModel tipoLancamento);
    TipoLancamento Delete(int id);
    int Count();
}
