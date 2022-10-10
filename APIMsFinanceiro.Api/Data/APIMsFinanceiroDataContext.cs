using APIMsFinanceiro.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using APIMsFinanceiro.Data.Mapping;
using APIMsFinanceiro.API.Models.Entities;

namespace APIMsFinanceiro.Data
{
    public class APIMsFinanceiroDataContext : DbContext
    {
        public APIMsFinanceiroDataContext(DbContextOptions<APIMsFinanceiroDataContext> options) : base(options)
        {

        }

        public DbSet<TipoLancamento> TiposLancamento { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LancamentoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new TipoLancamentoMap());
        }
    }
}
