using Castle.Core.Interceptor;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    public interface IInterceptingFilterFactory
    {
        IInterceptor create_for(Specification<IInvocation> specification);
    }

    public class InterceptingFilterFactory : IInterceptingFilterFactory
    {
        public IInterceptor create_for(Specification<IInvocation> specification)
        {
            return new InterceptingFilter(specification);
        }
    }
}