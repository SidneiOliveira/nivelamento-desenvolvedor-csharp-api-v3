namespace Questao5.Infrastructure.Entities
{
    public class Idempotencia
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public string TransactionResult { get; set; }
    }
}
