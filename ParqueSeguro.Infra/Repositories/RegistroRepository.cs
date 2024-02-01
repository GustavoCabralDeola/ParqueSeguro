using Microsoft.EntityFrameworkCore;
using ParqueSeguro.Core.Entities;
using ParqueSeguro.Core.InputModels;
using ParqueSeguro.Core.Interfaces.Respositories;
using ParqueSeguro.Core.ViewModels;
using ParqueSeguro.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Infra.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly Context _context;

        public RegistroRepository(Context context)
        {
            _context = context;
        }
        public async Task AdicionarAsync(MarcarEntradaInputModel registroModel)
        {
            var registro = new Registro(registroModel.Placa);
            await _context.Registros.AddAsync(registro);
            await SalvarAlteracoesAsync();
        }

        public async Task<List<RegistroViewModel>> ObterRegistrosAsync()
        {
            var registros = await _context.Registros.ToListAsync();
            return registros.Select(w => new RegistroViewModel(w.Id, w.Placa, w.HoraChegada, w.HoraSaida, w.Duracao, w.TotalHora, w.Preco, w.ValorPagar)).ToList();
        }



        public async Task <RegistroViewModel> ObterRegistroPorPlacaAsync(string placa)
        {
            var registro = await _context.Registros.FirstOrDefaultAsync(w => w.Placa == placa && w.HoraChegada != null && !w.HoraSaida.HasValue);
            return new RegistroViewModel(registro.Id, registro.Placa, registro.HoraChegada, registro.HoraSaida, registro.Duracao, registro.TotalHora, registro.Preco, registro.ValorPagar);
        }

        public async Task<RegistroViewModel> ObterRegistroPorIdAsync(int id)
        {
            var registro = await _context.Registros.FirstOrDefaultAsync(w => w.Id == id);
            return new RegistroViewModel(registro.Id, registro.Placa, registro.HoraChegada, registro.HoraSaida, registro.Duracao, registro.TotalHora, registro.Preco, registro.ValorPagar); ;
        }
        
        public async Task MarcarSaida(MarcarSaidaInputModel marcarSaidaInputModel)
        {
            var registro = await _context.Registros.FirstOrDefaultAsync(w => w.Id == marcarSaidaInputModel.Id);
            registro.MarcarSaida(marcarSaidaInputModel.HoraSaida, marcarSaidaInputModel.Duracao, marcarSaidaInputModel.TotalHora, marcarSaidaInputModel.Preco, marcarSaidaInputModel.ValorPagar);
            await SalvarAlteracoesAsync();
        }

        public async Task SalvarAlteracoesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
