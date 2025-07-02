using ParqueSeguro.Core.InputModels;
using ParqueSeguro.Core.ViewModels;

namespace ParqueSeguro.Core.Interfaces.Services
{
    public interface IRegistroService
    {
        Task MarcarEntrada(MarcarEntradaInputModel marcarEntradaInputModel);

        Task MarcarSaida(int id);

        Task AlterarAsync(MarcarEntradaInputModel marcarEntradaInputModel);

        Task<List<RegistroViewModel>> ObterRegistrosAsync();

        Task<RegistroViewModel> ObterRegistroPorPlacaAsync(string placaVeiculo);

        Task <RegistroViewModel> ObterRegistroPorId(int id);

        Task DeletarRegistro(string placa);
    }
}
