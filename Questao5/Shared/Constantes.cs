namespace Questao5.Shared
{
    public static class Constantes
    {
        public static string GET_SALDO_CONTA_CORRENTE = "SELECT idmovimento AS Id, idcontacorrente AS ContaCorrenteId, datamovimento AS Datamovimento, tipomovimento AS Tipomovimento, valor AS Valor FROM [movimento] WHERE idcontacorrente = '{0}';";
        public static string MOVIMENTAR_CONTA_CORRENTE = "INSERT INTO movimento(idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) VALUES('{0}', '{1}', '{2}', '{3}', {4});";
        public static string GET_CONTA_CORRENTE_INFO = "SELECT idcontacorrente AS Id, numero AS Numero, nome as Nome, ativo AS Ativo FROM [contacorrente] WHERE idcontacorrente = '{0}';";

        public static string GET_CREDITO_CONTA = "SELECT SUM(valor) AS Valor FROM [movimento] WHERE idcontacorrente = '{0}' AND tipomovimento = 'C' ;";
        public static string GET_DEBITO_CONTA = "SELECT SUM(valor) AS Valor FROM [movimento] WHERE idcontacorrente = '{0}' AND tipomovimento = 'D' ;";
    }
}
