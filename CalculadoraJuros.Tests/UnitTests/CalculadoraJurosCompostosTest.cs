using CalculadoraJuros.Domain.Classes;
using CalculadoraJuros.Domain.Interfaces;
using CalculadoraJuros.Services;
using System;
using Xunit;

namespace CalculadoraJuros.Tests
{
    public class CalculadoraJurosCompostosTest
    {

        /// <summary>
        /// Teste do método Calcular da CalculadoraJurosCompostos
        /// </summary>
        [Fact]
        public void CalcularTest()
        {

            decimal valorInicial = 100;
            int meses = 5;
            decimal taxaJuros = 0.01M;

            CalculadoraJurosCompostos calculadoraJuros = new CalculadoraJurosCompostos(valorInicial, meses, taxaJuros);

            Assert.Equal(105.1M, calculadoraJuros.Calcular());
        }
    }
}
