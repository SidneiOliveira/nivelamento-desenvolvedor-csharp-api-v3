using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {
        private readonly double TAXA_SAQUE = 3.5;
        public int Numero { get; private init; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }
        public ContaBancaria(int numero, string titular, double depositoInicial = 0)
        {
            Numero = numero;
            Titular = titular;
            Deposito(depositoInicial);
        }

        public void Deposito(double quantia)
        {
            Saldo += quantia;
        }

        public void Saque(double quantia)
        {
            quantia += TAXA_SAQUE;
            Saldo -= quantia;
        }
        public override string ToString() => $"Conta: {Numero}, Titular: {Titular}, Saldo: {string.Format("{0:C2}", Saldo, CultureInfo.InvariantCulture)}".ToString();
    }
}
