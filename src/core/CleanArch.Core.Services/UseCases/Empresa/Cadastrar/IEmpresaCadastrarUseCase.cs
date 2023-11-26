using CleanArch.Core.Services.Request.Empresa;
using CleanArch.Core.Services.Response.Empresa;
using CleanArch.Core.Services.UseCases.Interfaces;

namespace CleanArch.Core.Services.UseCases.Empresa.Cadastrar
{
    public interface IEmpresaCadastrarUseCase : ICadastrarUseCase<EmpresaCadastroRequest, EmpresaCadastrarResponse>
    {
    }
}
