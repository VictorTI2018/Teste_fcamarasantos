using CleanArch.Core.Domain.Entities;
using CleanArch.Core.Domain.Interfaces.Repositories;
using CleanArch.Core.Services.Request.Veiculos;
using CleanArch.Core.Services.Response.Veiculos;
using CleanArch.Core.Services.Validation.Veiculos;
using CleanArch.Core.Shared.Exceptions;

namespace CleanArch.Core.Services.UseCases.Veiculos.Cadastrar
{
    public class VeiculosCadastrarUseCase : IVeiculosCadastrarUseCase
    {
        private readonly IVeiculoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public VeiculosCadastrarUseCase(IVeiculoRepository veiculoRepository, IUnitOfWork unitOfWork)
        {
            _repository = veiculoRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task<VeiculosCadastrarResponse> ExecuteAsync(VeiculosCadastroRequest  obj)
        {
            try
            {
                var validator = new VeiculosCadastroValidator();
                var result = validator.Validate(obj);

                if (!result.IsValid)
                    throw new ValidatorException(result.Errors.Select(x => x.ErrorMessage).ToList());


                VeiculosEntity veiculo = new(obj.Marca, obj.Modelo,
                    obj.Cor, obj.Placa, obj.Tipo, obj.EmpresaId);

                var entity = await _repository.AddASync(veiculo);
                var salved = await _unitOfWork.CommitAsync();

                return new VeiculosCadastrarResponse { Data = entity, Message = new List<string> { "" }, Status = salved > 0 };

            }
            catch(Exception ex)
            {
                throw new InfraException(ex);
            }
        }
    }
}
