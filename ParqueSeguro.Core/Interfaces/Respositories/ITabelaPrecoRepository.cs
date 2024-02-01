using ParqueSeguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Core.Interfaces.Respositories
{
    public interface ITabelaPrecoRepository
    {
        Task<TabelaPreco> ObterTabelaPrecoVigenteAsync(DateTime horaChegada);
    }
}
