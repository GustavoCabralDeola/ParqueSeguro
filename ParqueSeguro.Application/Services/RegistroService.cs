using ParqueSeguro.Core.Entities;
using ParqueSeguro.Core.InputModels;
using ParqueSeguro.Core.Interfaces.Respositories;
using ParqueSeguro.Core.Interfaces.Services;
using ParqueSeguro.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Application.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroRepository _registroRepository;

        public RegistroService(IRegistroRepository registroRepository)
        {
            _registroRepository = registroRepository;
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


        public async Task<List<RegistroViewModel>> ObterRegistrosAsync()
        {
            return await _registroRepository.ObterRegistrosAsync();
        }


    }
}
