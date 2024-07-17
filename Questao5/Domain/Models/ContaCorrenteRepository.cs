using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Sqlite;
using Questao5.Shared;

namespace Questao5.Domain.Models
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public ContaCorrenteRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task MovimentarContaCorrenteAsync(MovimentarContaRequest request)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            await connection.ExecuteAsync(string.Format(Constantes.MOVIMENTAR_CONTA_CORRENTE, request.RequestId.ToString(), request.ContaId, DateTime.Now.ToString("dd/MM/yyy"), request.TipoMovimento, request.Valor));
        }
    }
}
