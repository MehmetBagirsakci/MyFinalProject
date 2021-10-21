using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    //Burası çalıştırılmak istenen bir metodun üstüne bakıyor.
    //Ordaki Interceptor'ları buluyordu. YANİ ASPECTLERİ BULUYORDU.
    //Ve onları çalıştırıyordu.
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); 
            //Yukarıdaki Log işleminde diyoruzki, hangi metot çalıştırılırsa logunu al. 
            //Artık şu metodun logunu aldım mı almadım mı kaygısı yok. Çalışan her metodun logu alınıyor.
            //YaniL ExceptionLogAspect bütün metotlara sen yazmasanda otomatik ekleniyor.
            //--Buraya PerformanceAspect eklese idik, her çalışacak metoda eklenir.

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }

}
