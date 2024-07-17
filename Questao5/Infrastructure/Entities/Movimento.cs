namespace Questao5.Infrastructure.Entities
{
    public class Movimento
    {
        public string Id { get; set; }
        public string ContaCorrenteId { get; set; }
        public string DataMovimento { get; set; }
        public string TipoMovimento { get; set; }
        public decimal Valor { get; set; }
    }
}
