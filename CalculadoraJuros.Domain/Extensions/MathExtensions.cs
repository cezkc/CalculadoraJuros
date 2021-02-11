using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Domain.Extensions
{
    public static class MathExtension
    {
        /// <summary>
        /// Trunca o valor em duas casas decimais sem arredondar
        /// </summary>
        public static decimal TruncateTwoDecimalPlaces(decimal number)
        {
            return Math.Truncate(100 * number) / 100;
        }
    }
}
