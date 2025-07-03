namespace ParqueSeguro.Core.Entities
{
    public class TabelaPreco : BasicEntity
    {
        public TabelaPreco(int id, DateTime dataInicio, DateTime dataFinal, double valorInicial, double valorAdicional)
        {
            Id = id;
            DataInicio = dataInicio;
            DataFinal = dataFinal;
            ValorInicial = valorInicial;
            ValorAdicional = valorAdicional;
        }

        public DateTime DataInicio { get; set; }

        public DateTime DataFinal { get; set; }
        public double ValorInicial { get; set; }
        public double ValorAdicional { get; set; }
    }
}
