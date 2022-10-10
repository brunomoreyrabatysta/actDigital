using APIMsFinanceiro.API.Enums;
using APIMsFinanceiro.API.Models.Entities;
using APIMsFinanceiro.API.Models.Repositories;
using APIMsFinanceiro.Data;
using APIMsFinanceiro.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APIMsFinanceiro.API.Infra.Repositories;

public class TipoLancamentoRepository : ITipoLancamentoRepository
{
    private readonly APIMsFinanceiroDataContext _context;

    public TipoLancamentoRepository(APIMsFinanceiroDataContext context)
    {
        _context = context;
    }

    public TipoLancamento Add(TipoLancamentoViewModel tipoLancamentoVM)
    {
        var tipoLancamento = new TipoLancamento
        {
            Id = 0,
            Descricao = tipoLancamentoVM.Descricao,
            Tipo = (ETipoLancamento)tipoLancamentoVM.Tipo
        };

        _context.TiposLancamento.Add(tipoLancamento);
        _context.SaveChanges();

        return tipoLancamento;
    }

    public TipoLancamento Delete(int id)
    {
        var tipoLancamento = _context.TiposLancamento.FirstOrDefault(tl => tl.Id == id);

        if (tipoLancamento != null)
        {
            _context.TiposLancamento.Remove(tipoLancamento);
            _context.SaveChangesAsync();
            return tipoLancamento;
        }

        return null;
    }

    public List<TipoLancamento> Get(int page,
                                    int pageSize)
    {
        var tiposLancamento = _context.TiposLancamento.Skip(page * pageSize).Take(pageSize).ToList();

        return tiposLancamento;
    }

    public TipoLancamento GetBydId(int id)
    {
        var tipoLancamento = _context.TiposLancamento.FirstOrDefault(tl => tl.Id == id);

        return tipoLancamento;
    }

    public TipoLancamento Update(int id,
                        TipoLancamentoViewModel tipoLancamentoVM)
    {
        var tipoLancamento = GetBydId(id);

        if (tipoLancamento == null)
            return null;

        tipoLancamento.Descricao = tipoLancamentoVM.Descricao;
        tipoLancamento.Tipo = (ETipoLancamento)tipoLancamentoVM.Tipo;


        _context.TiposLancamento.Update(tipoLancamento);
        _context.SaveChangesAsync();

        return tipoLancamento;
    }

    public int Count()
    {
        return _context.TiposLancamento.Count();
    }
}
