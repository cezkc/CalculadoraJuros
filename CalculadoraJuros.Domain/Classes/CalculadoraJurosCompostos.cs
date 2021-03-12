using CalculadoraJuros.Domain.Extensions;
using CalculadoraJuros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraJuros.Domain.Classes
{
    /// <summary>
    /// Implementação da calculadora para Juros Compostos
    /// </summary>
    public class CalculadoraJurosCompostos : ICalculadora
    {


        public CalculadoraJurosCompostos()
        {

        }

        /// <summary>
        /// Cálculo de juros compostos
        /// </summary>
        /// <param name="valorInicial">Valor inicial da dívida</param>
        /// <param name="meses">Tempo em meses para cálculo dos juros</param>
        /// <param name="taxaJuros">Taxa de Juros definida</param>
        /// <returns></returns>
        public decimal Calcular(decimal valorInicial, int meses, decimal taxaJuros)
        {
            var valorFinal = (double)valorInicial * Math.Pow(Convert.ToDouble((1 + taxaJuros)), meses);

            if (double.IsInfinity(valorFinal))
                throw new ArgumentException($"não é possível calcular o valor desejado (resultado infinito). Valor Inicial = {valorInicial}, Taxa de Juros = {taxaJuros}, Meses = {meses}");

            return MathExtension.TruncateTwoDecimalPlaces((decimal)valorFinal);
        }
    }
}
