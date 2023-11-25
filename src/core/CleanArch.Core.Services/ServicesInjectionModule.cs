using CleanArch.Core.Services.UseCases.Empresa.Cadastrar;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Core.Services
{
    public static class ServicesInjectionModule
    {
        public static void AddUseCasesModules(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaCadastrarUseCase, EmpresaCadastrarUseCase>();
        }
    }
}
