using System.Diagnostics;
using Castle.Core.Interceptor;
using MoMoney.Infrastructure.Extensions;

namespace MoMoney.Infrastructure.interceptors
{
    public interface ILoggingInterceptor : IInterceptor
    {}

    public class logging_interceptor : ILoggingInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();
            this.log().debug("{0}.{1} took {2}", invocation.TargetType.Name, invocation.Method.Name, stopwatch.Elapsed);
        }
    }
}