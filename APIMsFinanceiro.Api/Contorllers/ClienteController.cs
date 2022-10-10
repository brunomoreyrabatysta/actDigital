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
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _repository;

    public ClienteController(IClienteRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("v1/clientes")]
    public async Task<IActionResult> Get(
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var count = _repository.Count();

            var clientes = _repository.Get(page, pageSize);

            return Ok(new ResultViewModel<dynamic>(new
            {
                totalRegistros = count,
                totalPaginas = Math.Round(count / (decimal)pageSize),
                pagina = page,
                tamnhoPagina = pageSize,
                clientes
            }));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<List<Cliente>>(error: "ERCL001 - Não foi possível buscar o(s) cliente(s)!"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Cliente>>(error: "ERCL002 - Falha interna no servidor!"));
        }
    }



    [HttpGet("v1/clientes/{id:int}")]
    public async Task<IActionResult> GetById(
        [FromRoute] int id)
    {
        try
        {
            var cliente = _repository.GetBydId(id);

            if (cliente == null)
                return NotFound(new ResultViewModel<Cliente>(error: "ERCL003 - Não foi encontrado o cliente!"));

            return Ok(new ResultViewModel<Cliente>(cliente));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cliente>(error: "ERCL004 - Não foi possível buscar o cliente!"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Cliente>(error: "ERCL005 - Falha interna no servidor!"));
        }
    }


    [HttpPost("v1/clientes")]
    public async Task<IActionResult> Post(
        [FromBody] ClienteViewModel clienteVM)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Cliente>(ModelState.GetErros()));

        try
        {
            var cliente = _repository.Add(clienteVM);

            return Created($"v1/clientes/{cliente.Id}", new ResultViewModel<Cliente>(cliente));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cliente>(error: "ERCL006 - Não foi possível incluir o cliente!"));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Cliente>(error: "ERCL007 - Falha interna no servidor!"));
        }
    }

    [HttpPut("v1/clientes/{id:int}")]
    public async Task<IActionResult> Put(
        [FromRoute] int id,
        [FromBody] ClienteViewModel clienteVM)
    {
        try
        {
            var cliente = _repository.Update(id, clienteVM);

            if (cliente == null)
                return NotFound(new ResultViewModel<Cliente>(error: "ERCL008 - Não foi encontrado o cliente!"));

            return Ok(new ResultViewModel<Cliente>(cliente));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cliente>(error: "ERCL009 - Não foi possível alterar  o cliente!"));
        }

        catch
        {
            return StatusCode(500, new ResultViewModel<Cliente>(error: "ERCL010 - Falha interna no servidor!"));
        }
    }

    [HttpDelete("v1/clientes/{id:int}")]
    public async Task<IActionResult> Delete(
        [FromRoute] int id)
    {
        try
        {
            var cliente = _repository.Delete(id);

            if (cliente == null)
                return NotFound(new ResultViewModel<Cliente>(error: "ERCL011 - Não foi encontrado o cliente!"));

            return Ok(new ResultViewModel<Cliente>(cliente));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cliente>(error: "ERCL012 - Não foi possível excluir  o cliente!"));
        }

        catch
        {
            return StatusCode(500, new ResultViewModel<Cliente>(error: "ERCL013 - Falha interna no servidor!"));
        }
    }
}
