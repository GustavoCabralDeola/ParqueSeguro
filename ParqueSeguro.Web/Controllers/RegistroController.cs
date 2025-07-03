using Microsoft.AspNetCore.Mvc;
using ParqueSeguro.Core.Entities;
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
            RegistroViewModel registroViewModel = await _registroService.ObterRegistroPorPlacaAsync(placa);

             if (registroViewModel is not null)
{
                await _registroService.MarcarSaida(registroViewModel.Id);
            }

            return RedirectToAction("Index");
        }



        [HttpPost]

        public async Task <IActionResult> MarcarSaidaVeiculo(int id)
        {
            await _registroService.MarcarSaida(id);
            return RedirectToAction("Index");            
        }

        [HttpGet]
        public async Task <IActionResult> AlterarPlaca(string placa)
        {
            if (string.IsNullOrEmpty(placa))
            {
                return Content("Placa não encontrada vazio!");
            }

            var registro = await _registroService.ObterRegistroPorPlacaAsync(placa);

            if (registro is null)
            {
                return NotFound();
            }

            var inputModel = new MarcarEntradaInputModel
            {
                Placa = registro.Placa,

                PlacaAntiga = registro.Placa
            };

            return View(inputModel);
          
        }


        [HttpPost]
        public async Task<IActionResult> AlterarPlacaVeiculo(MarcarEntradaInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AlterarPlaca", model);
            }

            await _registroService.AlterarAsync(model);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public async Task<IActionResult> ObterRegistros() 
        {
            var registros = await _registroService.ObterRegistrosAsync();
            if (registros is null)
            {
                return NotFound();
            }
            return Ok(registros);
        }

        /*[HttpPost]*/
        public async Task <IActionResult> Deletar(string placa)
        {
            if (string.IsNullOrEmpty(placa))
            {
                return Content("Parâmetro placa está nulo ou vazio!");
            }

            return View();
        }

        [HttpPost]

        public async Task <IActionResult> DeletarRegistro(string placa) 
        {
            var registro = await _registroService.ObterRegistroPorPlacaAsync(placa);

            if (registro is null)
            {
                return NotFound();
            }
            await _registroService.DeletarRegistro(placa);
            return RedirectToAction("Index");
        }
    }
}
