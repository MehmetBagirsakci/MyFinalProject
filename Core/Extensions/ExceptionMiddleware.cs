using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext,e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = "Internal Server Error"
            }.ToString());
        }
    }
}
//_next: sıradaki middleware

//RequestDelegate : using Microsoft.AspNetCore.Http;
//HttpStatusCode : using System.Net;

//I M P R O V M E N T - İ Y İ L E Ş T İ R M E - InfoCode özel exceptionlar
//1. YÖNTEM
//public async Task InvokeAsync(HttpContext httpContext)
//{
//    try
//    {
//        await _next(httpContext);
//    }
//    catch (Exception e)
//    {
//        await HandleExceptionAsync(httpContext, e);
//    }
//}

//private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
//{
//    httpContext.Response.ContentType = "application/json";
//    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

//    string message = "Internal Server Error";

//    if (e.GetType() == typeof(ValidationException))
//    {
//        message = e.Message;
//        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

//    }

//    if (e.GetType() == typeof(AuthorizeException))
//    {
//        message = e.Message;
//        httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
//    }

//    return httpContext.Response.WriteAsync(new ErrorDetails
//    {
//        Message = message,
//        StatusCode = httpContext.Response.StatusCode
//    }.ToString());
//}
//    }


//    public class AuthorizeException : Exception
//    {
//        public AuthorizeException(string message) : base(message)
//        {

//        }
//    }

//--------------------------------------------------------------------------
//I M P R O V M E N T - İ Y İ L E Ş T İ R M E - InfoCode özel exceptionlar
//2. YÖNTEM
//public async Task InvokeAsync(HttpContext httpContext)
//{
//    try
//    {
//        await _next(httpContext);
//    }

//    catch (ValidationException e)
//    {
//        await HandleExceptionAsync(httpContext, e, e.Message);
//    }

//    catch (OzelException e)
//    {
//        await HandleExceptionAsync(httpContext, e, e.Message);
//    }

//    catch (Exception e)
//    {
//        await HandleExceptionAsync(httpContext, e, "Internal Server Error");
//    }
//}



//private Task HandleExceptionAsync(HttpContext httpContext, Exception exception, string message)
//{
//    httpContext.Response.ContentType = "application/json";
//    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//    return httpContext.Response.WriteAsync(new ErrorDetails()
//    {
//        StatusCode = httpContext.Response.StatusCode,
//        Message = message
//    }.ToString());
//}
//    }
//    public class OzelException : Exception
//    {
//    }