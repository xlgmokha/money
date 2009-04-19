using System.Collections.Generic;
using Castle.Core.Interceptor;

namespace MoMoney.Infrastructure.proxies.Interceptors
{
    public interface IMethodCallTracker<TypeToProxy> : IInterceptor
    {
        TypeToProxy target { get; }
        IEnumerable<string> methods_to_intercept();
    }
}