using Microsoft.EntityFrameworkCore;
using ParqueSeguro.Core.Entities;
using ParqueSeguro.Core.InputModels;
using ParqueSeguro.Core.Interfaces.Respositories;
using ParqueSeguro.Core.ViewModels;
using ParqueSeguro.Infra.Persistence;
using System.Linq;

namespace ParqueSeguro.Infra.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly Context _context;

        public RegistroRepository(Context context) => _context = context;

        public async Task AdicionarAsync(MarcarEntradaInputModel marcarEntradaInputModel)
        {
            Registro registro = new Registro(marcarEntradaInputModel.Placa);
            await _context.Registros.AddAsync(registro);
            await SalvarAlteracoesAsync();
         }

        public async Task<List<RegistroViewModel>> ObterRegistrosAsync()
        {
            List<Registro> listaRegistros = await _context.Registros.ToListAsync();
            return listaRegistros.Select(w => new RegistroViewModel(w.Id, w.Placa, w.HoraChegada, w.HoraSaida, w.Duracao, w.TotalHora, w.Preco, w.ValorPagar)).ToList();
        }

        public async Task<RegistroViewModel> ObterRegistroPorPlacaAsync(string placa)
        {
            Registro? registro = await _context.Registros.Where(w => w.Placa == placa).OrderByDescending(w => w.HoraChegada).FirstOrDefaultAsync();
            if (registro is null)
            {

                return null;
            }
            return new RegistroViewModel(registro.Id, registro.Placa, registro.HoraChegada, registro.HoraSaida, registro.Duracao, registro.TotalHora, registro.Preco, registro.ValorPagar);
        }

        public async Task<RegistroViewModel> ObterRegistroPorIdAsync(int id)
        {
            Registro? registro = await _context.Registros.FirstOrDefaultAsync(w => w.Id == id);
            return new RegistroViewModel(registro.Id, registro.Placa, registro.HoraChegada, registro.HoraSaida, registro.Duracao, registro.TotalHora, registro.Preco, registro.ValorPagar); ;
        }

        public async Task MarcarSaida(MarcarSaidaInputModel marcarSaidaInputModel)
        {
            Registro? registro = await _context.Registros.FirstOrDefaultAsync(w => w.Id == marcarSaidaInputModel.Id);
            registro.MarcarSaida(marcarSaidaInputModel.HoraSaida, marcarSaidaInputModel.Duracao, marcarSaidaInputModel.TotalHora, marcarSaidaInputModel.Preco, marcarSaidaInputModel.ValorPagar);
            await SalvarAlteracoesAsync();
        }

        public async Task AlterarAsync(MarcarEntradaInputModel marcarEntradaInputModel)
        {
            Registro? registro = await _context.Registros.Where(w => w.Placa == marcarEntradaInputModel.PlacaAntiga).FirstOrDefaultAsync();

            if (registro is not null)
            {
                registro.AlterarPlaca(marcarEntradaInputModel.Placa);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Registro não encontrado.");
            }
        }

        public async Task DeletarRegistro(string placa)
        {
            Registro? registro = await _context.Registros.Where(w => w.Placa == placa).FirstOrDefaultAsync();

            if (registro is not null)
            {
                _context.Registros.Remove(registro);
                await _context.SaveChangesAsync();
            }
        }


        public async Task SalvarAlteracoesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
