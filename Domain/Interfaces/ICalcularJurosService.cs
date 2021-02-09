using System;
using System.Threading.Tasks;

namespace CalculadoraJuros.Domain.Interfaces
{
    public interface ICalcularJurosService
    {
        /// <summary>
        /// Calcula os Juros em cima do tempo X Taxa informados
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="meses"></param>
        /// <param name="taxaJuros"></param>
        /// <returns></returns>
        decimal CalcularJuros(decimal valorInicial, int meses, decimal taxaJuros);

        /// <summary>
        /// Busca através da API de JurosAPI a Taxa de Juros
        /// </summary>
        /// <returns></returns>
        Task<decimal> GetTaxaJuros();
    }
}
