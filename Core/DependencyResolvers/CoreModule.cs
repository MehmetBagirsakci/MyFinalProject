using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //IMemoryCache _memoryCache; .NET Core kendisi injection yapıyor.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            //Redis ile cacheleme yapmak isteseydik şu satırı silerdik. serviceCollection.AddMemoryCache();
            //serviceCollection.AddSingleton<ICacheManager, RedisCacheManager>();

            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}//IHttpContextAccessor:NUGET Microsoft.AspNetCore.Http
