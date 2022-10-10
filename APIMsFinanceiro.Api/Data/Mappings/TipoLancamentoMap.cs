using APIMsFinanceiro.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIMsFinanceiro.Data.Mappings
{
    public class TipoLancamentoMap : IEntityTypeConfiguration<TipoLancamento>
    {
        public void Configure(EntityTypeBuilder<TipoLancamento> builder)
        {
            // Tabela
            builder.ToTable("TipoLancamento");

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

            builder.Property(x => x.Tipo);            
        }
    }
}
