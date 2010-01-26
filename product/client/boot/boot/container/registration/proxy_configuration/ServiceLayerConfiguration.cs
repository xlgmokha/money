using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    class ServiceLayerConfiguration<T> : Configuration<ProxyBuilder<T>>
    {
        public void configure(ProxyBuilder<T> item)
        {
            item.add_interceptor(Lazy.load<INotifyProgressInterceptor>()).intercept_all();
            item.add_interceptor(Lazy.load<IUnitOfWorkInterceptor>()).intercept_all();

            //item
            //    .add_interceptor(
            //    new SecuringProxy(new IsInRole(WindowsBuiltInRole.User.ToString())
            //                          .or(new IsInRole(WindowsBuiltInRole.Administrator.ToString()))))
            //    .intercept_all();
        }
    }
}