using CleanArch.Core.Domain.Interfaces.Repositories;
using CleanArch.Infra.SQLServer.Context;
using CleanArch.Infra.SQLServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.SQLServer
{
    public static class InfraInjectionModule
    {
        public static void AddRepositoryModule(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void AddSqlServerModule(this IServiceCollection service, string connection)
        {
            service.AddDbContext<EstacionamentoSqlServerContext>(options =>
            {
                options.UseSqlServer(connection);
            });
        }
    }
}
