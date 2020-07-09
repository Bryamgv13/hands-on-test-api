using System;
using System.Linq;
using System.Reflection;
using HandsOnTest.Domain.Ports;
using HandsOnTest.Domain.Services;
using HandsOnTest.Infrastructure.Adapters;
using HandsOnTest.Infrastructure.Config;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HandsOnTest.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.Load("HandsOnTest.Application"), typeof(Startup).Assembly);
            services.AddHttpClient();
            services.AddTransient(typeof(IEmployeesRepository), typeof(EmployeesRepository));
            services.AddTransient(typeof(CalculateSalaryService));
            services.AddTransient(typeof(Factory));
            var ApiEmployees = new ApiEmployeesConfig();
            ApiEmployees.UrlEmployees = Environment.GetEnvironmentVariable("URL_EMPLOYEES") ?? Configuration.GetValue<string>("ApiEmployees");
            string[] origins = Configuration.GetSection("Cross:UrlOrigins").Get<System.Collections.Generic.IEnumerable<string>>().ToArray();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builderx => builderx.WithOrigins(origins)
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .AllowCredentials()
                    );
            });
            services.AddSingleton(apiEmployees => ApiEmployees);
            services.AddControllers();
            services.AddSwaggerDocument();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
