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
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 25)
    {
        var tiposLancamentoRS = _repository.Get(page, pageSize);

        return Ok(tiposLancamentoRS);
    }

    [HttpGet("v1/tipos-lancamento/{id:int}")]
    public async Task<IActionResult> GetById(
        [FromRoute] int id)
    {
        var tipoLancamentoRS = _repository.GetBydId(id);

        if (!tipoLancamentoRS.Sucess)
            return StatusCode(500, tipoLancamentoRS);

        return Ok(tipoLancamentoRS);
    }

    [HttpPost("v1/tipos-lancamento")]
    public async Task<IActionResult> Post(
        [FromBody] TipoLancamentoViewModel tipoLancamentoVM)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<TipoLancamento>(ModelState.GetErros()));

        var tipoLancamentoRS = _repository.Add(tipoLancamentoVM);

        if (tipoLancamentoRS.Sucess)
        {
            var tipoLancamento = tipoLancamentoRS.Data;

            return Created($"v1/tipos-lancamento/{tipoLancamento.Id}", tipoLancamentoRS);
        }
        else
            return StatusCode(500, tipoLancamentoRS);

    }

    [HttpPut("v1/tipos-lancamento/{id:int}")]
    public async Task<IActionResult> Put(
        [FromRoute] int id,
        [FromBody] TipoLancamentoViewModel tipoLancamentoVM)
    {
        var tipoLancamentoRS = _repository.Update(id, tipoLancamentoVM);

        if (!tipoLancamentoRS.Sucess)
            return StatusCode(500, tipoLancamentoRS);

        return Ok(tipoLancamentoRS);
    }

    [HttpDelete("v1/tipos-lancamento/{id:int}")]
    public async Task<IActionResult> Delete(
        [FromRoute] int id)
    {
        var tipoLancamentoRS = _repository.Delete(id);

        if (!tipoLancamentoRS.Sucess)
            return StatusCode(500, tipoLancamentoRS);

        return Ok(tipoLancamentoRS);
    }
}
