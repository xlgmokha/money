using MoMoney.Infrastructure.proxies;
using MoMoney.Infrastructure.Threading;
using MoMoney.Utility.Core;

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