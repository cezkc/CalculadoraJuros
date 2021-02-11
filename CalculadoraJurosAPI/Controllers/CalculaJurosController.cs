using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CalculadoraJuros.Domain.Classes;
using CalculadoraJuros.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CalculadoraJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        public readonly IBuscarDadosExternosService _buscarDadosExternosService;

        public CalculaJurosController(IBuscarDadosExternosService buscarDadosExternosService)
        {
            _buscarDadosExternosService = buscarDadosExternosService;
        }

        /// <summary>
        /// Calcula os juros do valor informado pelos meses e taxa em vigor
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="meses"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get(decimal valorInicial, int meses)
        {
            var taxaJuros = await _buscarDadosExternosService.GetTaxaJuros();
            var calculadora = new CalculadoraJurosCompostos(valorInicial, meses, taxaJuros);
            decimal resultado = 0M;

            try
            {
                resultado = calculadora.Calcular();
            }
            catch (Exception ex)
            {
                var message = new string[] { ex.Message };
               return BadRequest(new ErrorModel(message));
            }

            return Ok(resultado);
        }
    }
}
