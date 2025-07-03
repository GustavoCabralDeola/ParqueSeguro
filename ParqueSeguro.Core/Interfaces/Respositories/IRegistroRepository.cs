using ParqueSeguro.Core.InputModels;
using ParqueSeguro.Core.ViewModels;

namespace ParqueSeguro.Core.Interfaces.Respositories
{
    public interface IRegistroRepository
    {
        Task AdicionarAsync(MarcarEntradaInputModel registroModel);

        Task AlterarAsync(MarcarEntradaInputModel model);

        Task<List<RegistroViewModel>> ObterRegistrosAsync();

        Task <RegistroViewModel> ObterRegistroPorPlacaAsync(string placa);

        Task<RegistroViewModel> ObterRegistroPorIdAsync(int id);
        
        Task MarcarSaida(MarcarSaidaInputModel marcarSaidaInputModel);

        Task DeletarRegistro(string placa);

        Task SalvarAlteracoesAsync();

    }
}
