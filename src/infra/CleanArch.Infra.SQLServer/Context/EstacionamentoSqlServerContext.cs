using CleanArch.Infra.SQLServer.MapperConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArch.Infra.SQLServer.Context
{
    public class EstacionamentoSqlServerContext : DbContext
    {
        public EstacionamentoSqlServerContext(DbContextOptions<EstacionamentoSqlServerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaEntityMapperConfig());
            modelBuilder.ApplyConfiguration(new EnderecoEntityMapperConfig());

            base.OnModelCreating(modelBuilder);
        }

    }

    public class EstacionamentoSqlServerContextBuilder : IDesignTimeDbContextFactory<EstacionamentoSqlServerContext>
    {
        public EstacionamentoSqlServerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstacionamentoSqlServerContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Estacionamento;Trusted_Connection=True;Encrypt=False");
            return new EstacionamentoSqlServerContext(optionsBuilder.Options);
        }
    }
}
