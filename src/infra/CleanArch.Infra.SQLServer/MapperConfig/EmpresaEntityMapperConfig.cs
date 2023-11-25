using CleanArch.Core.Domain.Entities;
using CleanArch.Core.Domain.Entities.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.SQLServer.MapperConfig
{
    public class EmpresaEntityMapperConfig : AuditEntityMapperConfig<EmpresaEntity>
    {
        protected override void ApplyBuilder(EntityTypeBuilder<EmpresaEntity> builder)
        {
            builder.ToTable("Empresa");

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .HasColumnName("Nome");

            builder.Property(e => e.CNPJ)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .HasColumnName("CNPJ");

            builder.Property(e => e.Telefone)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .HasColumnName("Telefone");

            builder.Property(e => e.QuantidadeVagasCarros)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("QuantidadeVagasCarros");

            builder.Property(e => e.QuantidadeVagasMotos)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("QuantidadeVagasMotos");

            builder.HasOne(e => e.Endereco).WithOne(e => e.Empresa)
                .HasForeignKey<EnderecoEntity>(e => e.EmpresaId);

        }
    }
}
