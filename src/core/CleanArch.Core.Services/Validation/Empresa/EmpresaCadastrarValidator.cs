using CleanArch.Core.Services.Request.Empresa;
using FluentValidation;

namespace CleanArch.Core.Services.Validation.Empresa
{
    public class EmpresaCadastrarValidator : AbstractValidator<EmpresaCadastroRequest>
    {
        public EmpresaCadastrarValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(x => $"Campo {nameof(x.Nome)} é obrigatório!");
        }
    }
}
