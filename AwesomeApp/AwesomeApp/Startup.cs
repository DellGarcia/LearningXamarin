using Microsoft.Extensions.DependencyInjection;
using System;
using AwesomeApp.Services;
using AwesomeApp.ViewModels;
using System.Net.Http;

namespace XamWebApiClient
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider;

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add services
            services.AddHttpClient<IUserService, UserService>(c =>
            {
                c.BaseAddress = new Uri("https://neat-moth-3.loca.lt/api/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            }); 

            //add viewmodels
            services.AddTransient<MainPageViewModel>();
            services.AddTransient<TestViewModel>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => ServiceProvider.GetService<T>();
    }
}