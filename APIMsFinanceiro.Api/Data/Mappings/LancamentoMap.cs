using System.Collections.Generic;
using APIMsFinanceiro.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMsFinanceiro.Data.Mapping
{
    public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            // Tabela
            builder.ToTable("Lancamento");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Data);
            builder.Property(x => x.Valor);

            // Relacionamentos
            builder
                 .HasOne(x => x.TipoLancamento)
                 .WithMany(x => x.Lancamentos)
                 .OnDelete(DeleteBehavior.Cascade);
            
            // Relacionamentos
            builder
                 .HasOne(x => x.Cliente)
                 .WithMany(x => x.Lancamentos)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
