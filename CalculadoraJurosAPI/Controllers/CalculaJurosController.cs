using CalculadoraJuros.Domain.Classes;
using CalculadoraJuros.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CalculadoraJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        public readonly IBuscarDadosExternosService _buscarDadosExternosService;
        public readonly ICalculadora _calculadoraJuros;

        public CalculaJurosController(IBuscarDadosExternosService buscarDadosExternosService, ICalculadora calculadoraJuros)
        {
            _buscarDadosExternosService = buscarDadosExternosService;
            _calculadoraJuros = calculadoraJuros;
        }

        /// <summary>
        /// Calcula os juros do valor informado sobre meses e taxa em vigor
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="meses"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get(decimal valorInicial, int meses)
        {
            decimal resultado = 0M;
            try
            {
                var taxaJuros = await _buscarDadosExternosService.GetTaxaJuros();
                resultado = _calculadoraJuros.Calcular(valorInicial, meses, taxaJuros);
            }
            catch (ArgumentException ex)
            {
                var message = new string[] { ex.Message };
                return BadRequest(new ErrorModel(message));
            }
            catch (Exception ex)
            {
                var message = new string[] { ex.Message };
                return StatusCode(500, new ErrorModel(message));
            }

            return Ok(resultado);
        }
    }
}
