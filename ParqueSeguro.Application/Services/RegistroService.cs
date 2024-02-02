using Microsoft.Win32;
using ParqueSeguro.Core.Entities;
using ParqueSeguro.Core.InputModels;
using ParqueSeguro.Core.Interfaces.Respositories;
using ParqueSeguro.Core.Interfaces.Services;
using ParqueSeguro.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var tabelaPreco = await _tabelaPrecoRepository.ObterTabelaPrecoVigenteAsync(registroViewModel.HoraChegada);

            

            registroViewModel.Preco = tabelaPreco.ValorInicial;

            double duracaoEmHoras = registroViewModel.Duracao.Value.TotalHours;

            if (duracaoEmHoras <= MetadeDoTempoDaHoraInicial)
            {
                registroViewModel.ValorPagar = tabelaPreco.ValorInicial / 2;
            }
            else
            {
                // Adicionando uma hora se a fração de horas for maior que 0.16666
                var fracaoHoras = Math.Truncate(duracaoEmHoras) - duracaoEmHoras;
                if (fracaoHoras > 0.16666)
                {
                    registroViewModel.Duracao += TimeSpan.FromHours(1);
                    
                }

                // Corrigindo cálculo do ValorPagar
                duracaoEmHoras = registroViewModel.Duracao.Value.TotalHours; // Recalcula a duração em horas
                if ((int)Math.Round(duracaoEmHoras) <= 1)
                {
                    registroViewModel.ValorPagar = tabelaPreco.ValorInicial;
                }
                else
                {
                    registroViewModel.ValorPagar = tabelaPreco.ValorInicial + (tabelaPreco.ValorAdicional * ((int)Math.Round(duracaoEmHoras) - 1));
                }


            }

                 

                registroViewModel.Duracao.ToString().Substring(0, 8);

                double? valorPagarDouble = registroViewModel.ValorPagar ?? 0.0;

                decimal valorPagarDecimal = Convert.ToDecimal(valorPagarDouble);

                
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
   

        public async Task AlterarAsync(int id, MarcarEntradaInputModel model)
        {
            await _registroRepository.AlterarAsync(id, model);
        }

        public async Task DeletarRegistro(int id)
        {
            await _registroRepository.DeletarRegistro(id);
        }
    }
}
