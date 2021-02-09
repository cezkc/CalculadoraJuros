﻿using CalculadoraJuros.Domain.Interfaces;
using CalculadoraJuros.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraJuros.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient(typeof(ICalcularJurosService), typeof(CalcularJurosService));
        }
    }
}