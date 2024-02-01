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

        Task<List<RegistroViewModel>> ObterRegistrosAsync();
    }
}
