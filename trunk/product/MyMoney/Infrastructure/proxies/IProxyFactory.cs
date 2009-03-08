using System.Collections.Generic;
using System.Linq;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;

namespace Ec.AuditTool.Infrastructure.Proxies
{
    public interface IProxyFactory
    {
        TypeToProxy CreateProxyFor<TypeToProxy>(TypeToProxy implementation, IEnumerable<IInterceptor> interceptors);
    }

    public class ProxyFactory : IProxyFactory
    {
        private readonly ProxyGenerator generator;

        public ProxyFactory() : this(new ProxyGenerator())
        {
        }

        public ProxyFactory(ProxyGenerator generator)
        {
            this.generator = generator;
        }

        public TypeToProxy CreateProxyFor<TypeToProxy>(TypeToProxy implementation,
                                                       IEnumerable<IInterceptor> interceptors)
        {
            return generator
                .CreateInterfaceProxyWithTarget<TypeToProxy>(implementation, interceptors.ToArray());
        }
    }
}