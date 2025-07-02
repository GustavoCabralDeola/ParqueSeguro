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

        public string PlacaAntiga { get; set; }


    }
}
