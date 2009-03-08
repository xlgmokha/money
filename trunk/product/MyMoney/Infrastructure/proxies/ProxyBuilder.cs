using System.Collections.Generic;
using System.Linq;
using Castle.Core.Interceptor;
using Ec.AuditTool.Infrastructure.Proxies;
using Ec.AuditTool.Infrastructure.Proxies.Interceptors;

namespace MoMoney.Infrastructure.proxies
{
    public interface IProxyBuilder<TypeToProxy>
    {
        IConstraintSelector<TypeToProxy> AddInterceptor<Interceptor>() where Interceptor : IInterceptor, new();
        TypeToProxy CreateProxyFor(TypeToProxy an_implementation_of_the_interface);
    }

    public class ProxyBuilder<TypeToProxy> : IProxyBuilder<TypeToProxy>
    {
        readonly IDictionary<IInterceptor, IInterceptorConstraint<TypeToProxy>> constraints;
        readonly IProxyFactory proxy_factory;
        readonly IInterceptorConstraintFactory constraint_factory;

        public ProxyBuilder() : this(new ProxyFactory(), new InterceptorConstraintFactory())
        {
        }

        public ProxyBuilder(IProxyFactory proxy_factory, IInterceptorConstraintFactory constraint_factory)
        {
            this.proxy_factory = proxy_factory;
            this.constraint_factory = constraint_factory;
            constraints = new Dictionary<IInterceptor, IInterceptorConstraint<TypeToProxy>>();
        }


        public IConstraintSelector<TypeToProxy> AddInterceptor<Interceptor>() where Interceptor : IInterceptor, new()
        {
            var constraint = constraint_factory.CreateFor<TypeToProxy>();
            constraints.Add(new Interceptor(), constraint);
            return constraint;
        }

        public TypeToProxy CreateProxyFor(TypeToProxy an_implementation_of_the_interface)
        {
            return proxy_factory.CreateProxyFor(an_implementation_of_the_interface,
                                                AllInterceptorsWithTheirConstraints());
        }

        IEnumerable<IInterceptor> AllInterceptorsWithTheirConstraints()
        {
            foreach (var pair in constraints)
            {
                var constraint = pair.Value;
                var interceptor = pair.Key;
                if (constraint.methods_to_intercept().Count() > 0)
                {
                    yield return new SelectiveInterceptor(constraint.methods_to_intercept(), interceptor);
                }
                else
                {
                    yield return interceptor;
                }
            }
        }
    }
}