using CalculadoraJuros.Domain.Extensions;
using Xunit;

namespace CalculadoraJuros.Tests
{
    public class MathExtensionsTest
    {
        /// <summary>
        /// Teste do método TruncateTwoDecimalPlacesTest
        /// </summary>
        [Fact]
        public void TruncateTwoDecimalPlacesTest()
        {
            decimal numberToTruncate = 1.1234567M;
            decimal expectedNumber = 1.12M;

            Assert.Equal(expectedNumber, MathExtension.TruncateTwoDecimalPlaces(numberToTruncate));
        }
    }
}
