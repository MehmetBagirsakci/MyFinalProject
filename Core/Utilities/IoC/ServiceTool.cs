using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Utilities.IoC
{
    //Tüm uygulamaları ilgilendiren injectionları 
    //Mesala (HttpContextAccessor, Cache vb. injectionlar) 
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
