using CalculadoraJuros.Domain.Interfaces;
using CalculadoraJuros.Services;
using System;
using Xunit;

namespace CalculadoraJuros.Tests
{
    public class CalcularJurosServiceTest
    {

        [Fact]
        public void CalcularJurosTest()
        {
            ICalcularJurosService calcularJurosService = new CalcularJurosService();

            decimal valorInicial = 100;
            int meses = 5;
            decimal taxaJuros = 0.01M;

            Assert.Equal(105.1M, calcularJurosService.CalcularJuros(valorInicial, meses, taxaJuros));
        }
    }
}
