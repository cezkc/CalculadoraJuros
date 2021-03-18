﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net.Http;
using Xunit;

namespace CalculadoraJuros.Tests
{
    public class JurosAPITest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;


        public JurosAPITest()
        {
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<JurosAPI.Startup>());

            _client = _server.CreateClient();
        }

        /// <summary>
        /// Teste da chamada API endpoint JurosAPI
        /// </summary>
        [Fact]
        public async void Test_Get_Juros()
        {

            var response = await _client.GetAsync("/TaxaJuros");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var valor = JsonConvert.DeserializeObject<decimal>(responseString);

            Assert.Equal(0.01M, valor);
        }

    }
}
