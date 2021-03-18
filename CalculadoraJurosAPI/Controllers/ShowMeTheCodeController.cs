using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculadoraJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {

        public ShowMeTheCodeController()
        {
        }


        /// <summary>
        /// O link para o GitHub com o código desenvolvido encontra-se no retorno dessa requisição.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok("https://github.com/cezkc/CalculadoraJuros");
        }
    }
}
