using System;
using Castle.Core.Interceptor;

namespace presentation.windows.infrastructure
{
    public class AnonymousInterceptor : IInterceptor
    {
        Action<IInvocation> interceptor;

        public AnonymousInterceptor(Action<IInvocation> interceptor)
        {
            this.interceptor = interceptor;
        }

        public void Intercept(IInvocation invocation)
        {
            interceptor(invocation);
        }
    }
}