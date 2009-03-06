using System;
using Castle.Core.Interceptor;

namespace MoMoney.Infrastructure.interceptors
{
    internal class lazy_loaded_interceptor<T> : IInterceptor
    {
        private readonly Func<T> get_the_implementation;

        public lazy_loaded_interceptor(Func<T> get_the_implementation)
        {
            this.get_the_implementation = get_the_implementation;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.GetConcreteMethodInvocationTarget();
            invocation.ReturnValue = method.Invoke(get_the_implementation(), invocation.Arguments);
        }
    }
}