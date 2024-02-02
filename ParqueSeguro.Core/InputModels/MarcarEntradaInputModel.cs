using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Core.InputModels
{
    public class MarcarEntradaInputModel
    {
        public MarcarEntradaInputModel(string placa)
        {
            Placa = placa;
        }

        public MarcarEntradaInputModel()
        {
            
        }

        public string Placa { get; set; }

        
    }
}
