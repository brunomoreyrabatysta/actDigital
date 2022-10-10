using APIMsFinanceiro.API.Enums;
using APIMsFinanceiro.API.Models.Entities;
using APIMsFinanceiro.API.Models.Repositories;
using APIMsFinanceiro.API.ViewModels;
using APIMsFinanceiro.Data;
using APIMsFinanceiro.Extensions;
using APIMsFinanceiro.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMsFinanceiro.API.Contorllers;

[Authorize]
[ApiController]
public class LancamentoController : ControllerBase
{
    private readonly ILancamentoRepository _repository;

    public LancamentoController(ILancamentoRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet("v1/lancamentos")]
    public async Task<IActionResult> Get(
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var count = _repository.Count();

            var lancamentos = _repository.Get(page, pageSize);

            return Ok(new ResultViewModel<dynamic>(new
            {
                totalRegistros = count,
                totalPaginas = Math.Round(count / (decimal)pageSize),
                pagina = page,
                tamnhoPagina = pageSize,
                lancamentos
            }));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<List<Lancamento>>(error: "ERLC001 - Não foi possível buscar o(s) lançamento(s)!"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Lancamento>>(error: "ERLC0002 - Falha interna no servidor!"));
        }
    }

    [HttpGet("v1/lancamentos/{id:int}")]
    public async Task<IActionResult> GetById(
        [FromRoute] int id)
    {
        try
        {
            var lancamentos = _repository.GetBydId(id);

            if (lancamentos == null)
                return NotFound(new ResultViewModel<Lancamento>(error: "ERLC003 - Não foi encontrado o lançamento!"));

            return Ok(new ResultViewModel<Lancamento>(lancamentos));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Lancamento>(error: "ERLC004 - Não foi possível buscar o lançamento!"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Lancamento>(error: "ERLC005 - Falha interna no servidor!"));
        }
    }

    [HttpPost("v1/lancamentos")]
    public async Task<IActionResult> Post(
        [FromBody] LancamentoViewModel lancamentoVM)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Lancamento>(ModelState.GetErros()));

        try
        {
            var lancamento = _repository.Add(lancamentoVM);

            if (lancamento == null)
                return NotFound(new ResultViewModel<Lancamento>(error: "ERLC009 - Não foi inserir o lançamento!"));

            return Created($"v1/lancamentos/{lancamento.Id}", new ResultViewModel<Lancamento>(lancamento));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Lancamento>(error: "ERLC006 - Não foi possível incluir o lançamento!"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<Lancamento>(error: "ERLC007 - Falha interna no servidor!"));
        }
    }

    [HttpPut("v1/lancamentos/{id:int}")]
    public async Task<IActionResult> Put(
        [FromRoute] int id,
        [FromBody] LancamentoViewModel lancamentoVM)
    {
        try
        {
            var lancamento = _repository.Update(id, lancamentoVM);
            
            if (lancamento == null)
                return NotFound(new ResultViewModel<Lancamento>(error: "ERLC014 - Não foi possível alterar o lançamento!"));

            return Ok(new ResultViewModel<Lancamento>(lancamento));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Lancamento>(error: "ERLC011 - Não foi possível alterar  o lançamento!"));
        }

        catch
        {
            return StatusCode(500, new ResultViewModel<Lancamento>(error: "ERLC012 - Falha interna no servidor!"));
        }
    }

    [HttpDelete("v1/lancamentos/{id:int}")]
    public async Task<IActionResult> DeletesAsync(
        [FromRoute] int id,
        [FromServices] APIMsFinanceiroDataContext context)
    {
        try
        {
            var lancamento = _repository.Delete(id);

            if (lancamento == null)
                return NotFound(new ResultViewModel<Lancamento>(error: "ERLC015 - Não foi encontrado o lançamento!"));

            return Ok(new ResultViewModel<Lancamento>(lancamento));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Lancamento>(error: "ERLC016 - Não foi possível excluir  o lançamento!"));
        }

        catch
        {
            return StatusCode(500, new ResultViewModel<Lancamento>(error: "ERLC017 - Falha interna no servidor!"));
        }
    }
}
