using Microsoft.EntityFrameworkCore;
using ParqueSeguro.Core.Entities;
using ParqueSeguro.Core.Interfaces.Respositories;
using ParqueSeguro.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Infra.Repositories
{
    public class TabelaPrecoRepository : ITabelaPrecoRepository
    {
        private readonly Context _context;

        public TabelaPrecoRepository(Context context)
        {
            _context = context; 
        }

        public async Task<TabelaPreco> ObterTabelaPrecoVigenteAsync(DateTime horaChegada)
        {
            return await _context.TabelaPrecos.SingleOrDefaultAsync(w => w.DataInicio <= horaChegada && w.DataFinal >= horaChegada);
        }
    }
}
