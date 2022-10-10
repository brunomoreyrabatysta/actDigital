using APIMsFinanceiro.API.Enums;
using APIMsFinanceiro.API.Models.Entities;
using APIMsFinanceiro.API.Models.Repositories;
using APIMsFinanceiro.Data;
using APIMsFinanceiro.Extensions;
using APIMsFinanceiro.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;
using System.Security.Cryptography.Xml;

namespace APIMsFinanceiro.Contorllers;

[Authorize]
[ApiController]
public class TipoLancamentoController : ControllerBase
{
    private readonly ITipoLancamentoRepository _repository;

    public TipoLancamentoController(ITipoLancamentoRepository repository)
    {
        _repository = repository;
    }


    [HttpGet("v1/tipos-lancamento")]
    public async Task<IActionResult> Get(
        [FromQuery]int page = 0,
        [FromQuery]int pageSize = 25)
    {
        try
        {
            var count = _repository.Count();

            var tiposLancamento = _repository.Get(page,pageSize);

            return Ok(new ResultViewModel<dynamic>(new
            {
                totalRegistros = count,
                totalPaginas = Math.Round(count / (decimal)pageSize),
                pagina = page,
                tamnhoPagina = pageSize,
                tiposLancamento
            }));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<List<TipoLancamento>>(error: "ERTP007 - Não foi possível buscar o(s) tipo(s) de lançamento!"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<TipoLancamento>>(error: "ERTP008 - Falha interna no servidor!"));
        }
    }

    [HttpGet("v1/tipos-lancamento/{id:int}")]
    public async Task<IActionResult> GetById(
        [FromRoute] int id)
    {
        try
        {
            var tipoLancamento = _repository.GetBydId(id);

            if (tipoLancamento == null)
                return NotFound(new ResultViewModel<TipoLancamento>(error: "ERTP011 - Não foi encontrado o tipo de lançamento!"));

            return Ok(new ResultViewModel<TipoLancamento>(tipoLancamento));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<TipoLancamento>(error: "ERTP009 - Não foi possível buscar o tipo de lançamento!"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<TipoLancamento>(error: "ERTP010 - Falha interna no servidor!"));
        }
    }

    [HttpPost("v1/tipos-lancamento")]
    public async Task<IActionResult> Post(
        [FromBody] TipoLancamentoViewModel tipoLancamentoVM)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<TipoLancamento>(ModelState.GetErros()));
        
        try
        {
            var tipoLancamento = _repository.Add(tipoLancamentoVM);            

            return Created($"v1/tipos-lancamento/{tipoLancamento.Id}", new ResultViewModel<TipoLancamento>(tipoLancamento));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<TipoLancamento>(error: "ERTP001 - Não foi possível incluir o tipo de lançamento!"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<TipoLancamento>(error: "ERTP002 - Falha interna no servidor!"));
        }
    }

    [HttpPut("v1/tipos-lancamento/{id:int}")]
    public async Task<IActionResult> Put(
        [FromRoute] int id,
        [FromBody] TipoLancamentoViewModel tipoLancamentoVM)
    {
        try
        {
            var tipoLancamento = _repository.Update(id, tipoLancamentoVM);

            if (tipoLancamento == null)
                return NotFound(new ResultViewModel<Cliente>(error: "ERTP008 - Não foi encontrado o tipo de lançamento!"));

            return Ok(new ResultViewModel<TipoLancamento>(tipoLancamento));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<TipoLancamento>(error: "ERTP003 - Não foi possível alterar  o tipo de lançamento!"));
        }

        catch
        {
            return StatusCode(500, new ResultViewModel<TipoLancamento>(error: "ERTP004 - Falha interna no servidor!"));
        }
    }

    [HttpDelete("v1/tipos-lancamento/{id:int}")]
    public async Task<IActionResult> Deletes(
        [FromRoute] int id)
    {
        try
        {
            var tipoLancamento = _repository.Delete(id);

            if (tipoLancamento == null)
                return NotFound(new ResultViewModel<TipoLancamento>(error: "ERTP013 - Não foi encontrado o tipo de lançamento!"));

            return Ok(new ResultViewModel<TipoLancamento>(tipoLancamento));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<TipoLancamento>(error: "ERTP005 - Não foi possível excluir  o tipo de lançamento!"));
        }

        catch
        {
            return StatusCode(500, new ResultViewModel<TipoLancamento>(error: "ERTP006 - Falha interna no servidor!"));
        }
    }
}
