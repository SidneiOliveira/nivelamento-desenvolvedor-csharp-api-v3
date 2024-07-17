using Questao5.Infrastructure.Entities;

namespace Questao5.Domain.Models
{
    public interface IContaCorrenteProvider
    {
        Task<ContaCorrente> GetAccountInfoAsync(string idContaCorrente);
        ConsultarSaldoResponse GetSaldoAsync(ContaCorrente contaCorrente);
    }
}
