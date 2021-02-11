using CalculadoraJuros.Domain.Extensions;
using CalculadoraJuros.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculadoraJuros.Services
{
    public class BuscarDadosExternosService : IBuscarDadosExternosService
    {
        public async Task<decimal> GetTaxaJuros()
        {
            var taxaJuros = 0M;
            using (var httpClient = new HttpClient())
            {
                using (var apiResponse = await httpClient.GetAsync("http://localhost:56149/taxaJuros"))
                {
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        string response = await apiResponse.Content.ReadAsStringAsync();
                        taxaJuros = JsonConvert.DeserializeObject<decimal>(response);
                    }
                }
            }
            return taxaJuros;
        }
    }
}
