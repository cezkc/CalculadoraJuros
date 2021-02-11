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
        public decimal ValorInicial { get; private set; }
        public int Meses { get; private set; }
        public decimal TaxaJuros { get; private set; }

        /// <param name="valorInicial">Valor inicial da dívida</param>
        /// <param name="meses">Tempo em meses para cálculo dos juros</param>
        /// <param name="taxaJuros">Taxa de Juros definida</param>
        public CalculadoraJurosCompostos(decimal valorInicial, int meses, decimal taxaJuros)
        {
            ValorInicial = valorInicial;
            Meses = meses;
            TaxaJuros = taxaJuros;
        }

        /// <summary>
        /// Cálculo de juros compostos
        /// </summary>
        /// <returns></returns>
        public decimal Calcular()
        {
            var valorFinal = (double)ValorInicial * Math.Pow(Convert.ToDouble((1 + TaxaJuros)), Meses);
            
            if (double.IsInfinity(valorFinal))
                throw new Exception($"não é possível calcular o valor desejado (resultado infinito). Valor Inicial = {ValorInicial}, Taxa de Juros = {TaxaJuros}, Meses = {Meses}");

            return MathExtension.TruncateTwoDecimalPlaces((decimal)valorFinal);
        }
    }
}
