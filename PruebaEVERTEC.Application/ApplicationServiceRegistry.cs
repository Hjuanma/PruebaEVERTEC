
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PruebaEVERTEC.Application.Adapters;
using PruebaEVERTEC.Application.Ports.Input;
using System.Reflection;

namespace PruebaEVERTEC.Application
{
    public static class ApplicationServiceRegistry
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistry).Assembly));
            services.AddTransient(typeof(IContactService), typeof(ContactService));
            return services;
        }
    }
}
