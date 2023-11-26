using CleanArch.Core.Services.UseCases.Empresa.Cadastrar;
using CleanArch.Core.Services.UseCases.Veiculos.Cadastrar;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Core.Services
{
    public static class ServicesInjectionModule
    {
        public static void AddUseCasesModules(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaCadastrarUseCase, EmpresaCadastrarUseCase>();
            services.AddScoped<IVeiculosCadastrarUseCase, VeiculosCadastrarUseCase>();
        }
    }
}
