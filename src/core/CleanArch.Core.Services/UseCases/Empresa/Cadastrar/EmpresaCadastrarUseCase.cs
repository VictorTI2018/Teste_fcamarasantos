using CleanArch.Core.Domain.Entities;
using CleanArch.Core.Domain.Entities.Aggregates;
using CleanArch.Core.Domain.Interfaces.Repositories;
using CleanArch.Core.Services.Request.Empresa;
using CleanArch.Core.Services.Response.Empresa;
using CleanArch.Core.Services.Validation.Empresa;
using CleanArch.Core.Shared.Exceptions;

namespace CleanArch.Core.Services.UseCases.Empresa.Cadastrar
{
    public class EmpresaCadastrarUseCase : IEmpresaCadastrarUseCase
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmpresaCadastrarUseCase(IEmpresaRepository empresaRepository, IUnitOfWork unitOfWork)
        {
            _empresaRepository = empresaRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task<EmpresaCadastrarResponse> ExecuteAsync(EmpresaCadastroRequest request)
        {
            try
            {
                var validator = new EmpresaCadastrarValidator();
                var result = validator.Validate(request);

                if (!result.IsValid)
                    throw new ValidatorException(result.Errors.Select(e => e.ErrorMessage).ToList());

                EmpresaEntity empresa = EmpresaCadastroRequest.AdapterEmpresaCadastroRequestToEmpresaEntity(request);

                var entity = await _empresaRepository.AddASync(empresa);
                await _unitOfWork.CommitAsync();

                return new EmpresaCadastrarResponse { Data = entity, Status = true, Message = new List<string> { "Empresa cadastrada com sucesso!" } };
            }
            catch (Exception ex)
            {
                throw new InfraException(ex);
            }
        }
    }
}
