using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
//ConfigureCustomExceptionMiddleware, WebAPI'de middleware kısmına eklenecek 
//İstese idik WebAPI de middleware kısmına aşağıdaki gibide yazabilirdik.
//app.UseMiddleware<ExceptionMiddleware>();

//IApplicationBuilder : using Microsoft.AspNetCore.Builder;