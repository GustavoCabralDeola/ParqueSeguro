using ParqueSeguro.Core.Entities;

namespace ParqueSeguro.Core.Interfaces.Respositories
{
    public interface ITabelaPrecoRepository
    {
        Task<TabelaPreco> ObterTabelaPrecoVigenteAsync(DateTime horaChegada);
    }
}
