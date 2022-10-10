using APIMsFinanceiro.API.Models.Entities;
using APIMsFinanceiro.API.ViewModels;
using APIMsFinanceiro.ViewModels;

namespace APIMsFinanceiro.API.Models.Repositories;

public interface IClienteRepository
{
    List<Cliente> Get(int page, int pageSize);
    Cliente GetBydId(int id);
    Cliente Add(ClienteViewModel clienteVM);
    Cliente Update(int id, ClienteViewModel clienteVM);
    Cliente Delete(int id);
    int Count();
}
