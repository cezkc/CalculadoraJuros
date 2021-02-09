using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculadoraJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        private static readonly decimal TAXA_JUROS = 0.01M;

        public TaxaJurosController()
        {
        }

        /// <summary>
        /// Retornar a Taxa de Juros em vigor
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<decimal> Get()
        {
            return Ok(TAXA_JUROS);
        }
    }
}
