using APIMsFinanceiro.API.Models.Entities;
using APIMsFinanceiro.API.Models.Repositories;
using APIMsFinanceiro.API.ViewModels;
using APIMsFinanceiro.Data;
using APIMsFinanceiro.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace APIMsFinanceiro.API.Infra.Repositories;

public class LancamentoRepository : ILancamentoRepository
{
    private readonly APIMsFinanceiroDataContext _context;

    public LancamentoRepository(APIMsFinanceiroDataContext context)
    {
        _context = context;
    }

    public Lancamento Add(LancamentoViewModel lancamentoVM)
    {
        var tipoLancamento = _context.TiposLancamento.FirstOrDefault(tl => tl.Id == lancamentoVM.TipoLancamentoId);

        if (tipoLancamento == null)
            return null;
            //new ResultViewModel<Lancamento>(error: "ERLC008 - Não foi encontrado o tipo de lançamento!"));

        var cliente = _context.Clientes.FirstOrDefault(cl => cl.Id == lancamentoVM.ClienteId);

        if (cliente == null)
            return null;
            //return new ResultViewModel<Lancamento>(error: "ERLC009 - Não foi encontrado o cliente!");

        var lancamento = new Lancamento
        {
            Id = 0,
            Descricao = lancamentoVM.Descricao,
            TipoLancamento = tipoLancamento,
            Cliente = cliente,
            Data = lancamentoVM.Data,
            Valor = lancamentoVM.Valor
        };

        _context.Lancamentos.Add(lancamento);
        _context.SaveChanges();

        return lancamento;
    }

    public int Count()
    {
        return _context.Lancamentos.Count();
    }

    public Lancamento Delete(int id)
    {
        var lancamento = _context.Lancamentos.FirstOrDefault(l => l.Id == id);

        if (lancamento == null)
            return null;

        _context.Lancamentos.Remove(lancamento);
        _context.SaveChanges();

        return lancamento;
    }

    public List<Lancamento> Get(int page, int pageSize)
    {
        return _context.Lancamentos
            .Skip(page * pageSize)
            .Take(pageSize)
            .Include(l => l.Cliente)
            .Include(l => l.TipoLancamento)
            .ToList();
    }

    public Lancamento GetBydId(int id)
    {
        return _context.Lancamentos.Include(l => l.Cliente).Include(l => l.TipoLancamento).FirstOrDefault(l => l.Id == id);
    }

    public Lancamento Update(int id, LancamentoViewModel lancamentoVM)
    {
        var lancamento = _context.Lancamentos.FirstOrDefault(l => l.Id == id);

        if (lancamento == null)
            return null;            

        var tipoLancamento = _context.TiposLancamento.FirstOrDefault(tl => tl.Id == lancamentoVM.TipoLancamentoId);

        if (tipoLancamento == null)
            return null;

        var cliente = _context.Clientes.FirstOrDefault(cl => cl.Id == lancamentoVM.ClienteId);

        if (cliente == null)
            return null;

        lancamento.Descricao = lancamentoVM.Descricao;
        lancamento.TipoLancamento = tipoLancamento;
        lancamento.Cliente = cliente;
        lancamento.Valor = lancamentoVM.Valor;
        lancamento.Data = lancamentoVM.Data;


        _context.Lancamentos.Update(lancamento);
        _context.SaveChanges();

        return lancamento;
    }
}
