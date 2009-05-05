using System.Security.Principal;
using System.Threading;
using Castle.Core.Interceptor;
using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    public class InterceptingFilter : IInterceptor
    {
        readonly ISpecification<IPrincipal> filter;

        public InterceptingFilter(ISpecification<IPrincipal> filter)
        {
            this.filter = filter;
        }

        public void Intercept(IInvocation invocation)
        {
            if (filter.is_satisfied_by(Thread.CurrentPrincipal)) invocation.Proceed();
            else this.log().debug("call to {0} was blocked");
        }
    }
}