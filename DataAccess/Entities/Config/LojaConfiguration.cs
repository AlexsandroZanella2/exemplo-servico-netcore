using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exemplo.ServicoNetCore.DataAccess.Entities.Config
{
    public class LojaConfiguration : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.ToTable("lojas");

            builder.Property(x => x.Id).HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(x => x.Nome).HasColumnName("nome");
            builder.Property(x => x.Uf).HasColumnName("uf");
            builder.Property(x => x.Cnpj).HasColumnName("cnpj");
        }
    }
}
