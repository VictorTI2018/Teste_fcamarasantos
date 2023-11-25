using CleanArch.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.SQLServer.MapperConfig
{
    public abstract class BaseEntityMapperConfig<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id).IsClustered();
            ApplyBuilder(builder);
        }

        protected abstract void ApplyBuilder(EntityTypeBuilder<T> builder);
    }
}
