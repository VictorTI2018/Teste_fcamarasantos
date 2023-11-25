using CleanArch.Core.Domain.Entities.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.SQLServer.MapperConfig
{
    public class EnderecoEntityMapperConfig : BaseEntityMapperConfig<EnderecoEntity>
    {
        protected override void ApplyBuilder(EntityTypeBuilder<EnderecoEntity> builder)
        {
            builder.Property(e => e.Endereco)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnName("Endereco");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .HasColumnName("Bairro");

            builder.Property(e => e.Numero)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(10)
               .HasColumnName("Numero");

            builder.Property(e => e.Cidade)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .HasColumnName("Cidade");

            builder.Property(e => e.UF)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(2)
               .HasColumnName("UF");

        }
    }
}
