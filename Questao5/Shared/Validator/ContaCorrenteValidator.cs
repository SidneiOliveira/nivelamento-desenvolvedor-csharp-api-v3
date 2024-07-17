using FluentValidation;
using Questao5.Infrastructure.Entities;

namespace Questao5.Shared.Validator
{
    public class ContaCorrenteValidator : AbstractValidator<ContaCorrente>
    {
        public ContaCorrenteValidator()
        {
            RuleFor(m => m).NotNull().WithMessage("INVALID_ACCOUNT");
            RuleFor(m => m.Ativo).Must(SomenteAtivo).WithMessage("INACTIVE_ACCOUNT");
        }
        private bool SomenteAtivo(bool ativo)
        {
            return ativo;
        }
    }
}
