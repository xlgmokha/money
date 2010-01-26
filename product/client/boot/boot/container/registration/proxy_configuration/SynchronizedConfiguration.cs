using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy;
using gorilla.commons.utility;
using momoney.service.infrastructure.threading;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    class SynchronizedConfiguration<T> : Configuration<ProxyBuilder<T>>
    {
        public void configure(ProxyBuilder<T> item)
        {
            item.add_interceptor<RunOnUIThread>().intercept_all();
        }
    }
}