using System;
using Castle.Core.Interceptor;

namespace MoMoney.Infrastructure.proxies
{
    public interface IProxyFactory
    {
        TypeToProxy create_proxy_for<TypeToProxy>(Func<TypeToProxy> implementation, params IInterceptor[] interceptors);
    }
}