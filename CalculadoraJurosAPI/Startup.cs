using CalculadoraJuros.Configuration;
using CalculadoraJuros.Domain.Classes;
using CalculadoraJurosAPI.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CalculadoraJurosAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
             .ConfigureApiBehaviorOptions(options =>
              {
                  options.InvalidModelStateResponseFactory = actionContext =>
                  {
                      var modelState = actionContext.ModelState.Values;
                      return new BadRequestObjectResult(new ErrorModel(modelState));
                  };
              });

            services.Configure<AppSettingsConfig>(Configuration.GetSection("Config"));

            DependencyInjectionConfig.Configure(services);
            SwaggerConfig.ConfigureServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculadora de Juros V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
