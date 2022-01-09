using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Logging
{
    public class UserLogAspect : MethodInterception
    {
        LoggerServiceBase _loggerServiceBase;
        IHttpContextAccessor _httpContextAccessor;
        public UserLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            LogDetailWithUser logDetailWithUser = GetLogDetail(invocation);
            logDetailWithUser.UserId = GetUserId();
            _loggerServiceBase.Info(logDetailWithUser);
        }

        private LogDetailWithUser GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }
            var logDetailWithUser = new LogDetailWithUser
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };
            return logDetailWithUser;
        }

        private string GetUserId()
        {
            return _httpContextAccessor.HttpContext.User.UserId();
        }
    }
}
