using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Infrastructure.Castle.DynamicProxy;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    class ServiceLayerConfiguration<T> : IConfiguration<IProxyBuilder<T>>
    {
        public void configure(IProxyBuilder<T> item)
        {
            item.add_interceptor(Lazy.load<IUnitOfWorkInterceptor>()).intercept_all();
            item.add_interceptor(Lazy.load<INotifyProgressInterceptor>()).intercept_all();

            //item
            //    .add_interceptor(
            //    new SecuringProxy(new IsInRole(WindowsBuiltInRole.User.ToString())
            //                          .or(new IsInRole(WindowsBuiltInRole.Administrator.ToString()))))
            //    .intercept_all();
        }
    }
}