namespace Questao5.Domain.Models
{
    public class ConsultarSaldoResponse
    {
        public string? NumeroConta { get; set; }
        public string? NomeTitular { get; set; }
        public string? DataHoraConsulta { get; set; }
        public string? ValorSaldoAtual { get; set; }
    }
}
