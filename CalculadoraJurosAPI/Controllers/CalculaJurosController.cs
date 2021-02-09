using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
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
        public readonly ICalcularJurosService _calcularJurosService;

        public CalculaJurosController(ICalcularJurosService calcularJurosService)
        {
            _calcularJurosService = calcularJurosService;
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
            var taxaJuros = await _calcularJurosService.GetTaxaJuros();
            var valorCalculado = _calcularJurosService.CalcularJuros(valorInicial, meses, taxaJuros);
           
            return Ok(valorCalculado);
        }
    }
}
