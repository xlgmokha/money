using Castle.Core.Interceptor;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    public class InterceptingFilter : IInterceptor
    {
        readonly ISpecification<IInvocation> condition;

        public InterceptingFilter(ISpecification<IInvocation> condition)
        {
            this.condition = condition;
        }

        public void Intercept(IInvocation invocation)
        {
            if (condition.is_satisfied_by(invocation)) invocation.Proceed();
        }
    }
}