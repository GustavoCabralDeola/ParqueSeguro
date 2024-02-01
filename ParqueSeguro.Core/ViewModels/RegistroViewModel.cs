using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
