using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using MoMoney.Infrastructure.interceptors;

namespace MoMoney.Infrastructure.proxies
{
    public class ProxyFactory : IProxyFactory
    {
        readonly ProxyGenerator generator;

        public ProxyFactory() : this(new ProxyGenerator())
        {
        }

        public ProxyFactory(ProxyGenerator generator)
        {
            this.generator = generator;
        }

        public TypeToProxy create_proxy_for<TypeToProxy>(TypeToProxy implementation,
                                                         IEnumerable<IInterceptor> interceptors)
        {
            return generator.CreateInterfaceProxyWithTarget<TypeToProxy>(implementation, interceptors.ToArray());
        }

        public TypeToProxy create_proxy_for<TypeToProxy>(Func<TypeToProxy> implementation, IEnumerable<IInterceptor> interceptors)
        {
            var proxy = create_proxy_for<TypeToProxy>(() => new LazyLoadedInterceptor<TypeToProxy>(implementation));
            return create_proxy_for(proxy, interceptors);
        }

        static T create_proxy_for<T>(Func<IInterceptor> interceptor)
        {
            return new ProxyGenerator().CreateInterfaceProxyWithoutTarget<T>(interceptor());
        }
    }
}