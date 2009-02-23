using System;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using MyMoney.Infrastructure.Container;
using MyMoney.Utility.Extensions;

namespace MyMoney.Infrastructure.interceptors
{
    public static class lazy
    {
        public static T Load<T>() where T : class
        {
            return create_proxy_for<T>(create_interceptor_for<T>());
        }

        private static IInterceptor create_interceptor_for<T>() where T : class
        {
            Func<T> get_the_implementation = resolve.dependency_for<T>;
            return new lazy_loaded_interceptor<T>(get_the_implementation.memorize());
        }

        private static T create_proxy_for<T>(IInterceptor interceptor)
        {
            return new ProxyGenerator().CreateInterfaceProxyWithoutTarget<T>(interceptor);
        }
    }
}