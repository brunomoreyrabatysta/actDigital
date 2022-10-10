using APIMsFinanceiro.API.Enums;
using APIMsFinanceiro.API.Models.Entities;
using APIMsFinanceiro.API.Models.Repositories;
using APIMsFinanceiro.API.ViewModels;
using APIMsFinanceiro.Data;
using APIMsFinanceiro.ViewModels;

namespace APIMsFinanceiro.API.Infra.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly APIMsFinanceiroDataContext _context;

    public ClienteRepository(APIMsFinanceiroDataContext context)
    {
        _context = context;
    }

    public Cliente Add(ClienteViewModel clienteVM)
    {
        var cliente = new Cliente
        {
            Id = 0,
            Nome = clienteVM.Nome
        };

        _context.Clientes.Add(cliente);
        _context.SaveChanges();

        return cliente;
    }

    public int Count()
    {
        return _context.Clientes.Count();
    }

    public Cliente Delete(int id)
    {
        var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

        if (cliente == null)
            return null;


        _context.Clientes.Remove(cliente);
        _context.SaveChanges();

        return cliente;
    }

    public List<Cliente> Get(int page, int pageSize)
    {
        var cliente = _context.Clientes.Skip(page * pageSize).Take(pageSize).ToList();

        return cliente;
    }

    public Cliente GetBydId(int id)
    {
        var cliente = _context.Clientes.FirstOrDefault(cl => cl.Id == id);

        return cliente;
    }

    public Cliente Update(int id, ClienteViewModel clienteVM)
    {
        var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

        if (cliente == null)
            return null;

        cliente.Nome = clienteVM.Nome;

        _context.Clientes.Update(cliente);
        _context.SaveChanges();

        return cliente;
    }
}
