using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrismDemo.ViewModels.Pages;
using PruebaEVERTEC.Application;
using PruebaEVERTEC.Infrastructure;
using PruebaEVERTEC.Services.Interfaces;
using PruebaEVERTEC.ViewModels.Pages;

namespace PruebaEVERTEC.Services
{
    public static class StatUpServices
    {
        private static IServiceProvider _serviceProvider;
        private const string baseUri = "https://usersignin.free.beeceptor.com/";

        /// <summary>
        /// Add services to dependency injection pool
        /// </summary>
        public static void ConfigurateServices()
        {
            

            var assembly = typeof(StatUpServices).Assembly;
            Stream resourceStream = assembly.GetManifestResourceStream("PruebaEVERTEC.appsettings.json");

            IConfiguration configuration = new ConfigurationBuilder().AddJsonStream(resourceStream).Build();

            var services = new ServiceCollection();

            services.AddHttpClient<IApiService, ApiService>(c =>
            {
                c.BaseAddress = new Uri(baseUri);
            });



            services.AddTransient<LoginPageViewModel>();
            services.AddTransient<ContactsViewModel>();
            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration);

            _serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => _serviceProvider.GetService<T>();

    }
}

