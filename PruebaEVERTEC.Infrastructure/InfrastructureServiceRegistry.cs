
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaEVERTEC.Application.Ports.Output.Repositories;
using PruebaEVERTEC.Infrastructure.Adapters;
using PruebaEVERTEC.Infrastructure.Clients;
using PruebaEVERTEC.Infrastructure.Models;
using System.Net.Http;
using System;

namespace PruebaEVERTEC.Infrastructure
{
    public static class InfrastructureServiceRegistry
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ApiSettings>(config.GetSection("ApiSettings"));
            services.AddHttpClient("custom")
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(config.GetSection("ApiSettings").GetSection("UrlString").Value);
                })
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    var handler = new HttpClientHandler();
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                    return handler;
                });
            
            services.AddTransient(typeof(IHttpCLient<>), typeof(HttpClient<>));
            services.AddTransient(typeof(IContactRepository), typeof(ContactRepository));
            services.AddTransient(typeof(ITechQuoteRepository), typeof(TechQuoteRepository));
            return services;
        }
    }
}
