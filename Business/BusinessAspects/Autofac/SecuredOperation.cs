using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;//Bu olmazsa GetService<> hata veriyor.
using System;
//nuget Autofac.Extensions.DependencyInjection ekledi.
//nuget Autofac.Extras.DynamicProxy
namespace Business.BusinessAspects.Autofac
{
    //JWT için
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //Windows Formda çalışan birisi aşağıdaki gibi çalışacak. Autofac'e gidip bilgileri alacak.
            //var productService = ServiceTool.ServiceProvider.GetService<IProductService>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
//IHttpContextAccessor: NUGET Microsoft.AspNetCore.Http
//GetService<>: using Castle.DynamicProxy;