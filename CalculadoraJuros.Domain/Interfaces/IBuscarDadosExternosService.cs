using System;
using System.Threading.Tasks;

namespace CalculadoraJuros.Domain.Interfaces
{
    public interface IBuscarDadosExternosService
    {

        /// <summary>
        /// Busca a taxa de juros vigente
        /// </summary>
        /// <returns></returns>
        Task<decimal> GetTaxaJuros();
    }
}
