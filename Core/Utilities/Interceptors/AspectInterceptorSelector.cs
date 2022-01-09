using Castle.DynamicProxy;
using Core.Aspects.Autofac.Exception;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
            
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); 
            //Yukarıdaki ExceptionLogAspect işleminde diyoruzki, hangi metotda bir exception olursa logunu al. 
            //Yani ExceptionLogAspect bütün metotlara sen yazmasanda otomatik ekleniyor.
            //--Buraya PerformanceAspect eklese idik, her çalışacak metoda eklenir.

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }

}
