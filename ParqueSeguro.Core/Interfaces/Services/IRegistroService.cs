using ParqueSeguro.Core.InputModels;
using ParqueSeguro.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Core.Interfaces.Services
{
    public interface IRegistroService
    {
        Task MarcarEntrada(MarcarEntradaInputModel model);

        Task MarcarSaida(int id);

        Task AlterarAsync(int id, MarcarEntradaInputModel model);

        Task<List<RegistroViewModel>> ObterRegistrosAsync();

        Task<RegistroViewModel> ObterRegistroPorPlacaAsync(string placa);

        Task <RegistroViewModel> ObterRegistroPorId(int id);

        Task DeletarRegistro(int id);
    }
}
