using System;
using System.Collections.Generic;
using Castle.Core.Interceptor;

namespace MoMoney.Infrastructure.proxies
{
    public interface IProxyFactory
    {
        TypeToProxy create_proxy_for<TypeToProxy>(TypeToProxy implementation, IEnumerable<IInterceptor> interceptors);

        TypeToProxy create_proxy_for<TypeToProxy>(Func<TypeToProxy> implementation, IEnumerable<IInterceptor> interceptors);
    }
}