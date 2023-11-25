using CleanArch.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.SQLServer.MapperConfig
{
    public abstract class AuditEntityMapperConfig<T> : BaseEntityMapperConfig<T>, IEntityTypeConfiguration<T>
        where T : AudityEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(b => b.Created)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()")
                .HasColumnName("_created");

            builder.Property(e => e.Updated)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()")
                .HasColumnName("_updated");

            ApplyBuilder(builder);
        }
    }
}
