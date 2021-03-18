using Microsoft.AspNetCore.Mvc;

namespace CalculadoraJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        private const decimal TAXA_JUROS = 0.01M;

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
