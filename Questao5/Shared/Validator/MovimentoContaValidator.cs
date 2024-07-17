using FluentValidation;
using Questao5.Domain;
using Questao5.Domain.Enumerators;

namespace Questao5.Shared.Validator
{
    public class MovimentoContaValidator : AbstractValidator<MovimentarContaRequest>
    {
        public MovimentoContaValidator()
        {
            RuleFor(m => m.Valor).Must(SomenteValoresPositivos).WithMessage("INVALID_VALUE");
            RuleFor(m => m.TipoMovimento).Must(SomenteCreditoDebito).WithMessage("INVALID_TYPE");
        }

        private bool SomenteCreditoDebito(string? tipoMovimento)
        {
            if (tipoMovimento is null)
            {
                return false;
            }
            return tipoMovimento.Equals(TipoMovimento.C) || tipoMovimento.Equals(TipoMovimento.D);
        }

        private bool SomenteValoresPositivos(decimal valor)
        {
            return valor <= 0;
        }
    }
}
