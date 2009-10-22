using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    class NoConfiguration<T> : Configuration<ProxyBuilder<T>>
    {
        public void configure(ProxyBuilder<T> item) {}
    }
}