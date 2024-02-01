using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Core.InputModels
{
    public class MarcarSaidaInputModel
    {
        public MarcarSaidaInputModel(int id, DateTime horaSaida, TimeSpan duracao, int totalHora, double preco, double valorPagar)
        {
            Id = id;
            HoraSaida = horaSaida;
            Duracao = duracao;
            TotalHora = totalHora;
            Preco = preco;
            ValorPagar = valorPagar;
        }

        public int Id { get; set; }

        public DateTime HoraSaida { get; set; }
        public TimeSpan Duracao { get; set; }
        public int TotalHora { get; set; }
        public double Preco { get; set; }

        public double ValorPagar { get; set; }
    }
}
