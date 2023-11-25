using CleanArch.Core.Services.Request.Empresa;
using CleanArch.Core.Services.Response.Empresa;

namespace CleanArch.Core.Services.UseCases.Empresa.Cadastrar
{
    public interface IEmpresaCadastrarUseCase
    {
        Task<EmpresaCadastrarResponse> ExecuteAsync(EmpresaCadastroRequest request);
    }
}
