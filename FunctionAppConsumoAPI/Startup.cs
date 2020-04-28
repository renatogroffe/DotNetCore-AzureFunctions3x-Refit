using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using FunctionAppConsumoAPI.Interfaces;
using Refit;

[assembly: FunctionsStartup(typeof(FunctionAppConsumoAPI.Startup))]
namespace FunctionAppConsumoAPI
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddRefitClient<IContagemClient>()
                .ConfigureHttpClient(
                    c => c.BaseAddress = new Uri(Environment.GetEnvironmentVariable("UrlAPIContagem")));
        }
    }
}