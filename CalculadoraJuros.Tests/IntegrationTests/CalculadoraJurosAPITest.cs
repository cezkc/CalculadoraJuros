using CalculadoraJurosAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace CalculadoraJuros.Tests
{
    public class CalculadoraJurosAPITest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public CalculadoraJurosAPITest()
        {
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void CalcularJuros()
        { 
            
            var response = await _client.GetAsync("/CalculaJuros?valorInicial=100&meses=5");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var valor = JsonConvert.DeserializeObject<decimal>(responseString);

            Assert.Equal(105.1M, valor);
        }

    }
}
