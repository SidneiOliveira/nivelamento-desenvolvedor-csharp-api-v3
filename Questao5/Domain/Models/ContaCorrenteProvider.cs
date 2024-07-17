using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Entities;
using Questao5.Infrastructure.Sqlite;
using Questao5.Shared;

namespace Questao5.Domain.Models
{
    public class ContaCorrenteProvider : IContaCorrenteProvider
    {
        private readonly DatabaseConfig databaseConfig;

        public ContaCorrenteProvider(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<ContaCorrente> GetAccountInfoAsync(string idContaCorrente)
        {
            try
            {
                using var connection = new SqliteConnection(databaseConfig.Name);
                return await connection.QuerySingleAsync<ContaCorrente>(string.Format(Constantes.GET_CONTA_CORRENTE_INFO, idContaCorrente));
            }
            catch
            {
                return new ContaCorrente();
            }
        }

        public ConsultarSaldoResponse GetSaldoAsync(ContaCorrente contaCorrente)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            decimal saldo = GetCreditos(contaCorrente);
            saldo -= GetDebitos(contaCorrente);

            return new ConsultarSaldoResponse() { NumeroConta = contaCorrente.Numero.ToString(), DataHoraConsulta = DateTime.Now.ToString("dd/MM/yyyy"), NomeTitular = contaCorrente.Nome, ValorSaldoAtual = saldo.ToString("N2") };
        }

        private decimal GetCreditos(ContaCorrente contaCorrente)
        {
            try
            {
                using var connection = new SqliteConnection(databaseConfig.Name);
                var saldo = connection.Query<decimal>(string.Format(Constantes.GET_CREDITO_CONTA, contaCorrente.Id));

                return saldo.FirstOrDefault();
            }
            catch
            {
                return 0;
            }
        }

        public decimal GetDebitos(ContaCorrente contaCorrente)
        {
            try
            {
                using var connection = new SqliteConnection(databaseConfig.Name);
                var saldo = connection.Query<decimal>(string.Format(Constantes.GET_DEBITO_CONTA, contaCorrente.Id));

                return saldo.FirstOrDefault();
            }
            catch
            {
                return 0;
            }
        }
    }
}
