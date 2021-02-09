using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        public ActionResult Get()
        {
            return Ok("https://github.com/cezkc/");
        }
    }
}
