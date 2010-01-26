using Castle.Core.Interceptor;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    public class InterceptingFilter : IInterceptor
    {
        readonly Specification<IInvocation> condition;

        public InterceptingFilter(Specification<IInvocation> condition)
        {
            this.condition = condition;
        }

        public void Intercept(IInvocation invocation)
        {
            if (condition.is_satisfied_by(invocation)) invocation.Proceed();
        }
    }
}