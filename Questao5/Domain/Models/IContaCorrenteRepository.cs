using Questao5.Infrastructure.Entities;

namespace Questao5.Domain.Models
{
    public interface IContaCorrenteRepository
    {
        Task MovimentarContaCorrenteAsync(MovimentarContaRequest request);
    }
}
