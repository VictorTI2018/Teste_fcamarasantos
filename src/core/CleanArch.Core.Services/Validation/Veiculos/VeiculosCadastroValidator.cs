using CleanArch.Core.Services.Request.Veiculos;
using FluentValidation;

namespace CleanArch.Core.Services.Validation.Veiculos
{
    public class VeiculosCadastroValidator : AbstractValidator<VeiculosCadastroRequest>
    {
        public VeiculosCadastroValidator()
        {
            RuleFor(v => v.Marca)
                .NotEmpty()
                .WithMessage(v => $"Campo {nameof(v.Marca)} é obrigatório");
        }
    }
}
