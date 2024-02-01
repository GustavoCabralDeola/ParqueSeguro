using ParqueSeguro.Core.Entities;
using ParqueSeguro.Core.InputModels;
using ParqueSeguro.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Core.Interfaces.Respositories
{
    public interface IRegistroRepository
    {
        Task AdicionarAsync(MarcarEntradaInputModel registroModel);

        Task<List<RegistroViewModel>> ObterRegistrosAsync();

        Task <RegistroViewModel> ObterRegistroPorPlacaAsync(string placa);

        Task<RegistroViewModel> ObterRegistroPorIdAsync(int id);

        Task MarcarSaida(MarcarSaidaInputModel marcarSaidaInputModel);
        Task SalvarAlteracoesAsync();

    }
}
