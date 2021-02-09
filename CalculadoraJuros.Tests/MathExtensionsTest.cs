﻿using CalculadoraJuros.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculadoraJuros.Tests
{
    public class MathExtensionsTest
    {
        [Fact]
        public void TruncateTwoDecimalPlacesTest()
        {
            decimal numberToTruncate = 1.1234567M;
            decimal expectedNumber = 1.12M;

            Assert.Equal(expectedNumber, MathExtension.TruncateTwoDecimalPlaces(numberToTruncate));
        }
    }
}
