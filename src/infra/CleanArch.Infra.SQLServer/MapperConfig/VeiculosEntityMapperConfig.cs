using CleanArch.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.SQLServer.MapperConfig
{
    public class VeiculosEntityMapperConfig : AuditEntityMapperConfig<VeiculosEntity>
    {
        protected override void ApplyBuilder(EntityTypeBuilder<VeiculosEntity> builder)
        {
            builder.ToTable("Veiculos");


            builder.Property(v => v.Modelo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnName("Modelo");

            builder.Property(v => v.Marca)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnName("Marca");

            builder.Property(v => v.Cor)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .HasColumnName("Cor");

            builder.Property(v => v.Placa)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .HasColumnName("Placa");

            builder.Property(v => v.Tipo)
                .IsRequired()
                .HasColumnType("int")
                .HasMaxLength(10)
                .HasColumnName("Tipo");

        }
    }
}
