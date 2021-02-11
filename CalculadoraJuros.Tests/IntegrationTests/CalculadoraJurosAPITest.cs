using CalculadoraJuros.Domain.Classes;
using JurosAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace CalculadoraJuros.Tests
{
    public class CalculadoraJurosAPITest
    {
        TestServer _server;
        HttpClient _client;
        public CalculadoraJurosAPITest()
        {
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<JurosAPI.Startup>());

            _client = _server.CreateClient();

        }

        /// <summary>
        /// Teste da chamada API endpoint CalcularJuros pelo modo correto
        /// </summary>
        [Fact]
        public async void Test_Calculate_Flux()
        {
            var response = await _client.GetAsync("/taxaJuros");
            var responseString = await response.Content.ReadAsStringAsync();
            var valorInicial = 100M;
            var meses = 5;
            response.EnsureSuccessStatusCode();
            var taxaJuros = JsonConvert.DeserializeObject<decimal>(responseString);

            var calculadora = new CalculadoraJurosCompostos(valorInicial, meses, taxaJuros);
            var resultado = calculadora.Calcular();

            Assert.Equal(105.1M, resultado);
        }

    }
}
