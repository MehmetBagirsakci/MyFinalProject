using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;//Bu olmazsa GetService<> hata veriyor.

namespace Core.Aspects.Autofac.Caching
{
    //CacheRemoveAspect Ne Zaman Çalışır?
    //Data bozulduğu zaman çalışır. Yani
    //1- Data güncellenirse
    //2- Yeni data eklenirse
    //3- Data silinirse
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
