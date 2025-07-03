using ParqueSeguro.Core.InputModels;
using ParqueSeguro.Core.Interfaces.Respositories;
using ParqueSeguro.Core.Interfaces.Services;
using ParqueSeguro.Core.ViewModels;

namespace ParqueSeguro.Application.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroRepository _registroRepository;

        private readonly ITabelaPrecoRepository _tabelaPrecoRepository;

        public RegistroService(IRegistroRepository registroRepository, ITabelaPrecoRepository tabelaPrecoRepository)
        {
            _registroRepository = registroRepository;
            _tabelaPrecoRepository  = tabelaPrecoRepository;
        }

        public async Task MarcarEntrada(MarcarEntradaInputModel model)
        {

            await _registroRepository.AdicionarAsync(model);

        }

        public async Task MarcarSaida(int id)
        {
            var registro = await _registroRepository.ObterRegistroPorIdAsync(id);
            registro.HoraSaida = DateTime.Now;

            CalcularDuracao(registro);

            CalcularTempo(registro);

            await CalcularValorAPagar(registro);

            var inputModel = new MarcarSaidaInputModel(registro.Id, registro.HoraSaida.Value, registro.Duracao.Value, registro.TotalHora.Value, registro.Preco.Value, registro.ValorPagar.Value); ;

            await _registroRepository.MarcarSaida(inputModel);
        }



        private void CalcularDuracao(RegistroViewModel registroModel)
        {
            registroModel.Duracao = registroModel.HoraSaida - registroModel.HoraChegada;
        }

        private void CalcularTempo(RegistroViewModel registroModel)
        {

            registroModel.TotalHora = registroModel.Duracao.HasValue ? (int)Math.Round(registroModel.Duracao.Value.TotalHours) : 0;
        }


        private const double MetadeDoTempoDaHoraInicial = 0.5;

 

        public async Task CalcularValorAPagar(RegistroViewModel registroViewModel)
        {
            const double VALOR_UNITARIO_HORA = 2.0;
            const int TOLERANCIA_MINUTOS = 10;

            var horaChegada = registroViewModel.HoraChegada;
            var horaSaida = registroViewModel.HoraSaida ?? DateTime.Now;
            registroViewModel.Duracao = horaSaida - horaChegada;

            double duracaoTotalMinutos = registroViewModel.Duracao.Value.TotalMinutes;

            int horasCompletas = (int)Math.Floor(registroViewModel.Duracao.Value.TotalHours);
            double minutosExcedentes = duracaoTotalMinutos - (horasCompletas * 60);

          
            int horasAPagar = 1;

            if (horasCompletas >= 1)
            {
                horasAPagar = horasCompletas;
            }

            if (minutosExcedentes > TOLERANCIA_MINUTOS)
            {
                horasAPagar += 1;
            }

            double valorPagar = horasAPagar * VALOR_UNITARIO_HORA;

            registroViewModel.Preco = VALOR_UNITARIO_HORA;
            registroViewModel.ValorPagar = valorPagar;

        }



        public async Task<List<RegistroViewModel>> ObterRegistrosAsync()
        {
            return await _registroRepository.ObterRegistrosAsync();
        }

        public async Task<RegistroViewModel> ObterRegistroPorId(int id)
        {
            return await _registroRepository.ObterRegistroPorIdAsync(id);
        }

        public async Task <RegistroViewModel> ObterRegistroPorPlacaAsync(string placa)
        {
            return await _registroRepository.ObterRegistroPorPlacaAsync(placa);
        }
   

        public async Task AlterarAsync(MarcarEntradaInputModel model)
        {
            await _registroRepository.AlterarAsync(model);
        }

        public async Task DeletarRegistro(string placa)
        {
            await _registroRepository.DeletarRegistro(placa);
        }
    }
}
