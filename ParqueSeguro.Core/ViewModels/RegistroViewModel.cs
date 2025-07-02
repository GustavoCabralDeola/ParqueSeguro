namespace ParqueSeguro.Core.ViewModels
{
    public class RegistroViewModel
    {
        public RegistroViewModel(int id, string placa, DateTime horaChegada, DateTime? horaSaida, TimeSpan? duracao, int? totalHora, double? preco, double? valorPagar)
        {
            Id = id;
            Placa = placa;
            HoraChegada = horaChegada;
            HoraSaida = horaSaida;
            Duracao = duracao;
            TotalHora = totalHora;
            Preco = preco;
            ValorPagar = valorPagar;
        }

        public int Id { get; set; }
        public string Placa { get; set; }

        public DateTime HoraChegada { get; set; }
        public DateTime? HoraSaida { get; set; }
        public TimeSpan? Duracao { get; set; }
        public int? TotalHora { get; set; }
        public double? Preco { get; set; }

        public double? ValorPagar { get; set; }

        public string PrecoFormatado => Preco.HasValue ? Preco.Value.ToString("C2") : "R$ 0,00";

        public string ValorPagarFormatado => ValorPagar.HasValue ? ValorPagar.Value.ToString("C2") : "R$ 0,00";

        public string DuracaoFormatada => Duracao.HasValue
        ? $"{(int)Duracao.Value.TotalHours:D2}:{Duracao.Value.Minutes:D2}:{Duracao.Value.Seconds:D2}"
        : "00:00:00";
    }
}
