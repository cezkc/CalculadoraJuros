using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace CalculadoraJuros.Configuration
{
    public static class SwaggerConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "Calculadora de Juros",
                    Version = "v1",
                    Description = "Calculadora de Juros",
                    Contact = new OpenApiContact
                    {
                        Name = "Cezar K de Carvalho",
                        Email = "cezar_kc@hotmail.com"
                    }
                });

                string applicationPath =
                PlatformServices.Default.Application.ApplicationBasePath;

                string applicationName =
                PlatformServices.Default.Application.ApplicationName;

                string xmlPathDoc =
                Path.Combine(applicationPath, $"{applicationName}.xml");

                swagger.IncludeXmlComments(xmlPathDoc);

            });
        }
    }
}
