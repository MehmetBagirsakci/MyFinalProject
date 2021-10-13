using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    //Extension yazabilmek için class ve metodun static olması gerekir.
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(
            this IServiceCollection serviceCollection,ICoreModule[] modules )
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
//IServiceCollection:using Microsoft.Extensions.DependencyInjection;
//NOT : IServiceCollection: Bizim Asp.Net uygulamamızın kısaca API'mizin
//service bağımlılıklarını eklediğimiz yada araya girmesini istediğimiz servisleri
//eklediğimiz collection'unun ta kendisidir.
//SONUÇ OLARAK ŞUNU YAPTIK.
//Burada yaptığımız hareket, bizim Core katmanıda dahil olmak üzere ekleyeceğimiz
//bütün injectionları bir arada toplayabileceğimiz bir yapıya dönüştü.