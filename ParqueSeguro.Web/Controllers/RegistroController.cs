using Microsoft.AspNetCore.Mvc;
using ParqueSeguro.Core.InputModels;
using ParqueSeguro.Core.Interfaces.Services;

namespace ParqueSeguro.Web.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IRegistroService _registroService;

        public RegistroController(IRegistroService registroService)
        {
            _registroService = registroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task <IActionResult> MarcarEntrada(MarcarEntradaInputModel model)
        {
            await _registroService.MarcarEntrada(model);
            return Ok();
        }

        [HttpPost]

        public async Task <IActionResult> MarcarSaida(int id)
        {
            await _registroService.MarcarSaida(id);
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
    }
}
