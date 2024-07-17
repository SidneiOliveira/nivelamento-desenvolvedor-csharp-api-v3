using Questao5.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Domain
{
    public class MovimentarContaRequest
    {
        public Guid RequestId { get; set; }

        [Required]
        public string? ContaId { get; set; }
        public decimal Valor { get; set; }

        [Required]
        [EnumDataType(typeof(TipoMovimento))]
        public string? TipoMovimento { get; set; }
    }
}
