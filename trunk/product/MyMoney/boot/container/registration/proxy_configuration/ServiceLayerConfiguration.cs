using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Infrastructure.Castle.DynamicProxy;
using Gorilla.Commons.Infrastructure.Castle.DynamicProxy.Interceptors;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    internal class ServiceLayerConfiguration<T> : IConfiguration<IProxyBuilder<T>>
    {
        public void configure(IProxyBuilder<T> item)
        {
            item.add_interceptor(Lazy.load<IUnitOfWorkInterceptor>()).intercept_all();
        }
    }
}