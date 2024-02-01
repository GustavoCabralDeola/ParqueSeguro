using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Core.Entities
{
    public class Registro : BasicEntity
    {
        public Registro(string placa)
        {
            Placa = placa;
            HoraChegada = DateTime.Now;
        }

        public string Placa { get; private set; }

        public DateTime HoraChegada { get; private set; }
        public DateTime? HoraSaida { get; private set; }
        public TimeSpan? Duracao { get; private set; }
        public int? TotalHora { get; private set; }
        public double? Preco { get; private set; }

        public double? ValorPagar { get; private set; }
    }
}
