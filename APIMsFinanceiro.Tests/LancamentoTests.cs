using APIMsFinanceiro.API.Models.Entities;

namespace APIMsFinanceiro.Tests;

[TestClass]
public class LancamentoTests
{
    private Cliente cliente;
    private TipoLancamento tipoLancamentoCredito;
    private TipoLancamento tipoLancamentoDebito;
    private Lancamento lancamentoCredito;
    private Lancamento lancamentoDebito;

    public LancamentoTests()
    {
        cliente = new Cliente();
        cliente.Id = 1;
        cliente.Nome = "Nome do cliente";

        tipoLancamentoCredito = new TipoLancamento();
        tipoLancamentoCredito.Id = 1;
        tipoLancamentoCredito.Descricao = "Crédito";
        tipoLancamentoCredito.Tipo = API.Enums.ETipoLancamento.Credito;

        tipoLancamentoDebito = new TipoLancamento();
        tipoLancamentoDebito.Id = 2;
        tipoLancamentoDebito.Descricao = "Débito";
        tipoLancamentoDebito.Tipo = API.Enums.ETipoLancamento.Debito;

        lancamentoCredito = new Lancamento();
        lancamentoCredito.Id = 1;
        lancamentoCredito.Cliente = cliente;
        lancamentoCredito.TipoLancamento = tipoLancamentoCredito;
        lancamentoCredito.Data = DateTime.Now;
        lancamentoCredito.Valor = 100;
        lancamentoCredito.Descricao = "Venda";

        lancamentoDebito = new Lancamento();
        lancamentoDebito.Id = 2;
        lancamentoDebito.Cliente = cliente;
        lancamentoDebito.TipoLancamento = tipoLancamentoDebito;
        lancamentoDebito.Data = DateTime.Now;
        lancamentoDebito.Valor = 25;
        lancamentoDebito.Descricao = "Estorno";
    }

    [TestMethod]
    public void VerificarClienteInstanciado()
    {
        Assert.AreNotEqual(null, cliente);
    }

    [TestMethod]
    public void VerificarClientePreenchido()
    {
        Assert.AreEqual(true, (cliente.Id != 0) && (!string.IsNullOrEmpty(cliente.Nome)));
    }

    [TestMethod]
    public void VerificarTipoLancamentoCreditoInstanciado()
    {
        Assert.AreNotEqual(null, tipoLancamentoCredito);
    }

    [TestMethod]
    public void VerificarTipoLancamentoCreditoPreenchido()
    {
        Assert.AreEqual(true, (tipoLancamentoCredito.Id != 0) && 
                                (!string.IsNullOrEmpty(tipoLancamentoCredito.Descricao)) &&
                                (tipoLancamentoCredito.Tipo != 0));
    }

    [TestMethod]
    public void VerificarLancamentoDebitoInstanciado()
    {
        Assert.AreNotEqual(null, lancamentoDebito);
    }

    [TestMethod]
    public void VerificarLancamentoDebitoPreenchido()
    {
        Assert.AreEqual(true, (lancamentoDebito.Id != 0) &&
                                (lancamentoDebito.Cliente != null) &&
                                (lancamentoDebito.TipoLancamento != null) &&
                                (lancamentoDebito.Data != DateTime.MinValue) &&
                                (lancamentoDebito.Valor != 0));
    }
}