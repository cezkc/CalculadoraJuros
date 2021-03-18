using CalculadoraJuros.Domain.Interfaces;
using CalculadoraJurosAPI.Util;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculadoraJuros.Services
{
    public class BuscarDadosExternosService : IBuscarDadosExternosService
    {
        private readonly IOptions<AppSettingsConfig> _config;
        public BuscarDadosExternosService(IOptions<AppSettingsConfig> config)
        {
            _config = config;
        }
        public async Task<decimal> GetTaxaJuros()
        {
            var taxaJuros = 0M;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (var apiResponse = await httpClient.GetAsync($"{_config.Value.JurosAPIAddress}/taxaJuros"))
                    {
                        if (apiResponse.IsSuccessStatusCode)
                        {
                            string response = await apiResponse.Content.ReadAsStringAsync();
                            taxaJuros = JsonConvert.DeserializeObject<decimal>(response);
                        }
                        else
                            throw new HttpRequestException(apiResponse.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    throw new HttpRequestException($"Erro na chamada da API TaxaJuros: {ex.Message}");
                }
            }
            return taxaJuros;
        }
    }
}
