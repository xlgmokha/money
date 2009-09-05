using Castle.Core.Interceptor;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    public interface IInterceptingFilterFactory
    {
        IInterceptor create_for(ISpecification<IInvocation> specification);
    }

    public class InterceptingFilterFactory : IInterceptingFilterFactory
    {
        public IInterceptor create_for(ISpecification<IInvocation> specification)
        {
            return new InterceptingFilter(specification);
        }
    }
}