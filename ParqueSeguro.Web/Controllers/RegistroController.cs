using Microsoft.AspNetCore.Mvc;
using ParqueSeguro.Application.Services;
using ParqueSeguro.Core.InputModels;
using ParqueSeguro.Core.Interfaces.Services;
using ParqueSeguro.Core.ViewModels;

namespace ParqueSeguro.Web.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IRegistroService _registroService;

        public RegistroController(IRegistroService registroService)
        {
            _registroService = registroService;
        }

        public async Task <IActionResult> Index()
        {

           var registro = await _registroService.ObterRegistrosAsync();
            return View(registro);
        }


        public IActionResult MarcarEntrada()
        {

            return View();
        }

        [HttpPost]
        public async Task <IActionResult> MarcarEntradaVeiculo(MarcarEntradaInputModel model)
        {
            await _registroService.MarcarEntrada(model);
            return RedirectToAction("Index");
        }

        public IActionResult MarcarSaida()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> MarcarSaidaVeiculoPlaca(string placa)
        {
            var registro = await _registroService.ObterRegistroPorPlacaAsync(placa);

            if (registro != null)
{
                await _registroService.MarcarSaida(registro.Id);
            }

            return RedirectToAction("Index");
        }



        [HttpPost]

        public async Task <IActionResult> MarcarSaidaVeiculo(int id)
        {
            await _registroService.MarcarSaida(id);
            return RedirectToAction("Index");            
        }

        public IActionResult AlterarPlaca()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AlterarPlacaVeiculo(int id, MarcarEntradaInputModel model)
        {
            await _registroService.AlterarAsync(id, model);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public async Task<IActionResult> ObterRegistros() 
        {
            var registros = await _registroService.ObterRegistrosAsync();
            if (registros == null)
            {
                return NotFound();
            }
            return Ok(registros);
        }


        public IActionResult Deletar()
        {
            return View();
        }

        [HttpPost]

        public async Task <IActionResult> DeletarRegistro(int id) 
        {
            _registroService.ObterRegistroPorId(id);
            await _registroService.DeletarRegistro(id);
            return RedirectToAction("Index");
        }
    }
}
