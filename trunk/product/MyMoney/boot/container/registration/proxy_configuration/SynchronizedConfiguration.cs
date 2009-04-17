using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.proxies;
using MoMoney.Infrastructure.Threading;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    internal class SynchronizedConfiguration<T> : IConfiguration<IProxyBuilder<T>>
    {
        public void configure(IProxyBuilder<T> item)
        {
            item.add_interceptor<RunOnUIThread>().intercept_all();
        }
    }
}