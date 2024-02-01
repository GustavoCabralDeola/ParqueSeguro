using ParqueSeguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Core.Interfaces.Respositories
{
    public interface IRegistroRepository
    {
        Task AdicionarAsync();

        Task<List<Registro>> ObterRegistrosAsync();

        Task SalvarAlteracoesAsync();
    }
}
