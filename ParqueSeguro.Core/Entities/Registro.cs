namespace ParqueSeguro.Core.Entities
{
    public class Registro : BasicEntity
    {
        public Registro(string placa)
        {
            Placa = placa;
            HoraChegada = DateTime.Now;
        }

        public string Placa { get; set; }

        public DateTime HoraChegada { get; private set; }
        public DateTime? HoraSaida { get; private set; }
        public TimeSpan? Duracao { get; private set; }
        public int? TotalHora { get; private set; }
        public double? Preco { get; private set; }

        public double? ValorPagar { get; private set; }

        public string PrecoFormatado => Preco.HasValue ? Preco.Value.ToString("C2") : "R$ 0,00";

        public string ValorPagarFormatado => ValorPagar.HasValue ? ValorPagar.Value.ToString("C2") : "R$ 0,00";

        public string DuracaoFormatada => Duracao.HasValue
        ? $"{(int)Duracao.Value.TotalHours:D2}:{Duracao.Value.Minutes:D2}:{Duracao.Value.Seconds:D2}"
        : "00:00:00";

        public void MarcarSaida(DateTime horaSaida, TimeSpan duracao, int totalHora, double preco, double valorAPagar)
        {
            HoraSaida = horaSaida;
            Duracao = duracao;
            TotalHora = totalHora;
            Preco = preco;
            ValorPagar = valorAPagar;
        }

        public void AlterarPlaca(string placa)
        {
            Placa = placa;

            
        }
    }
}
