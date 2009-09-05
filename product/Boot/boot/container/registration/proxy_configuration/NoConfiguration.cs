using Gorilla.Commons.Infrastructure.Castle.DynamicProxy;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    class NoConfiguration<T> : IConfiguration<IProxyBuilder<T>>
    {
        public void configure(IProxyBuilder<T> item)
        {
        }
    }
}