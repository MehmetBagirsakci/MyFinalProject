using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Utilities.IoC
{
    //ServiceTool bizim injection alt yapımızı aynen okuyabilmemize yarayan bir araç.
    //Tüm uygulamaları ilgilendiren injectionları 
    //Mesala (HttpContextAccessor, Cache vb. injectionlar) 
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        //.NET'in servislerini (IServiceCollection) al. Ve kendin onları build et.
        //Kısacası bu kod bizim WebAPI'de veya AutoFac'te oluşturduğumuz injectionları oluşturabilmemize yarıyor.
        //Bundan sonra biz istediğimiz herhangi bir interface'in servisteki karşılığını ServiceTool vasıtasıyla alabiliriz.
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
