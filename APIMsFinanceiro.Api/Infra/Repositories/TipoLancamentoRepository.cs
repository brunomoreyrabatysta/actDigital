using APIMsFinanceiro.API.Enums;
using APIMsFinanceiro.API.Models.Entities;
using APIMsFinanceiro.API.Models.Repositories;
using APIMsFinanceiro.Data;
using APIMsFinanceiro.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace APIMsFinanceiro.API.Infra.Repositories;

public class TipoLancamentoRepository : ITipoLancamentoRepository
{
    private readonly APIMsFinanceiroDataContext _context;

    public TipoLancamentoRepository(APIMsFinanceiroDataContext context)
    {
        _context = context;
    }

    private List<string> Validar(TipoLancamentoViewModel tipoLancamentoVM)
    {
        return Validar(tipoLancamentoVM, true);
    }

    private List<string> Validar(TipoLancamentoViewModel tipoLancamentoVM, bool isAdd)
    {
        List<string> errors = new List<string>();

        if (!isAdd)
        {
            if (tipoLancamentoVM.Id == 0)
                errors.Add("ERTP010 - O código do tipo do lançamento não foi preenchido!");
            else
            {
                var tipoLancamentoPQ = _context.TiposLancamento.FirstOrDefault(tp => tp.Id == tipoLancamentoVM.Id);
                if (tipoLancamentoPQ == null)
                    errors.Add("ERTP011 - O código do tipo do lançamento não existe cadastrado!");
            }
        }

        if (string.IsNullOrEmpty(tipoLancamentoVM.Descricao))
            errors.Add("ERTP007 - A descrição do tipo de lançamento não foi preenchida!");
        else if (tipoLancamentoVM.Descricao.Length < 3 || tipoLancamentoVM.Descricao.Length > 40)
            errors.Add("ERTP009 - A descrição está com um tamanho fora do permitido!");

        if (tipoLancamentoVM.Tipo == 0)
            errors.Add("ERTP010 - O tipo do lancaçmento não foi preenchido!");
        else if (tipoLancamentoVM.Tipo != (int)ETipoLancamento.Credito &&
                tipoLancamentoVM.Tipo != (int)ETipoLancamento.Debito &&
                tipoLancamentoVM.Tipo != (int)ETipoLancamento.Nulo)
            errors.Add("ERTP011 - O tipo do lancaçmento preenchido é inválido!");

        return errors;
    }

    private List<string> ValidarExclusao(TipoLancamentoViewModel tipoLancamentoVM)
    {
        List<string> errors = new List<string>();


        if (tipoLancamentoVM.Id == 0)
            errors.Add("ERTP010 - O código do tipo do lançamento não foi preenchido!");
        else
        {
            var tipoLancamentoPQ = _context.TiposLancamento.FirstOrDefault(tp => tp.Id == tipoLancamentoVM.Id);
            if (tipoLancamentoPQ == null)
                errors.Add("ERTP011 - O código do tipo do lançamento não existe cadastrado!");
        }

        return errors;
    }

    public ResultViewModel<TipoLancamento> Add(TipoLancamentoViewModel tipoLancamentoVM)
    {
        List<string> errors = Validar(tipoLancamentoVM);

        if (errors.Count > 0)
            return new ResultViewModel<TipoLancamento>(errors);

        var tipoLancamento = new TipoLancamento
        {
            Id = 0,
            Descricao = tipoLancamentoVM.Descricao,
            Tipo = (ETipoLancamento)tipoLancamentoVM.Tipo
        };

        try
        {
            _context.TiposLancamento.Add(tipoLancamento);
            _context.SaveChanges();

            return new ResultViewModel<TipoLancamento>(tipoLancamento);
        }
        catch (DbUpdateException)
        {
            return new ResultViewModel<TipoLancamento>(error: "ERTP001 - Não foi possível incluir o tipo de lançamento!");
        }
        catch
        {
            return new ResultViewModel<TipoLancamento>(error: "ERTP002 - Falha interna no servidor!");
        }
    }

    public ResultViewModel<TipoLancamento> Delete(int id)
    {
        var tipoLancamentoVM = new TipoLancamentoViewModel { Id = id };

        var errors = ValidarExclusao(tipoLancamentoVM);

        if (errors.Count > 0)
            return new ResultViewModel<TipoLancamento>(errors);

        try
        {
            var tipoLancamento = _context.TiposLancamento.FirstOrDefault(tl => tl.Id == tipoLancamentoVM.Id);

            _context.TiposLancamento.Remove(tipoLancamento);
            _context.SaveChangesAsync();

            return new ResultViewModel<TipoLancamento>(tipoLancamento);
        }
        catch (DbUpdateException)
        {
            return  new ResultViewModel<TipoLancamento>(error: "ERTP005 - Não foi possível excluir  o tipo de lançamento!");
        }

        catch
        {
            return new ResultViewModel<TipoLancamento>(error: "ERTP006 - Falha interna no servidor!");
        }

    }

    public ResultViewModel<dynamic> Get(int page,
                                    int pageSize)
    {
        try
        {
            var count = Count();

            var tiposLancamento = _context.TiposLancamento.Skip(page * pageSize).Take(pageSize).ToList();
            
            return new ResultViewModel<dynamic>(new
            {
                totalRegistros = count,
                totalPaginas = Math.Round(count / (decimal)pageSize),
                pagina = page,
                tamnhoPagina = pageSize,
                tiposLancamento
            });
        }
        catch (DbUpdateException)
        {
            return  new ResultViewModel<dynamic>(error: "ERTP007 - Não foi possível buscar o(s) tipo(s) de lançamento!");
        }
        catch
        {
            return new ResultViewModel<dynamic>(error: "ERTP008 - Falha interna no servidor!");
        }

    }

    public ResultViewModel<TipoLancamento> GetBydId(int id)
    {
        try
        {
            var tipoLancamento = _context.TiposLancamento.FirstOrDefault(tl => tl.Id == id);

            if (tipoLancamento == null)
                return new ResultViewModel<TipoLancamento>(error: "ERTP011 - Não foi encontrado o tipo de lançamento!");

            return new ResultViewModel<TipoLancamento>(tipoLancamento);
        }
        catch (DbUpdateException)
        {
            return new ResultViewModel<TipoLancamento>(error: "ERTP009 - Não foi possível buscar o tipo de lançamento!");
        }
        catch
        {
            return new ResultViewModel<TipoLancamento>(error: "ERTP010 - Falha interna no servidor!");
        }
    }

    public ResultViewModel<TipoLancamento> Update(int id,
                        TipoLancamentoViewModel tipoLancamentoVM)
    {
        tipoLancamentoVM.Id = id;

        var errors = Validar(tipoLancamentoVM, false);

        if (errors.Count > 0)
            return new ResultViewModel<TipoLancamento>(errors);

        TipoLancamento tipoLancamento = new TipoLancamento();

        try
        {
            tipoLancamento.Descricao = tipoLancamentoVM.Descricao;
            tipoLancamento.Tipo = (ETipoLancamento)tipoLancamentoVM.Tipo;

            _context.TiposLancamento.Update(tipoLancamento);
            _context.SaveChangesAsync();

            return new ResultViewModel<TipoLancamento>(tipoLancamento);
        }
        catch (DbUpdateException)
        {
            return new ResultViewModel<TipoLancamento>(error: "ERTP003 - Não foi possível alterar  o tipo de lançamento!");
        }

        catch
        {
            return new ResultViewModel<TipoLancamento>(error: "ERTP004 - Falha interna no servidor!");
        }
    }

    public int Count()
    {
        try
        {
            return _context.TiposLancamento.Count();
        }
        catch (Exception)
        {
            return 0;
        }
    }
}
