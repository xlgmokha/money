using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.Interceptors;
using MoMoney.Infrastructure.proxies;

namespace MoMoney.boot.container.registration
{
    internal class SynchronizedConfiguration<T> : IConfiguration<IProxyBuilder<T>>
    {
        public void configure(IProxyBuilder<T> item)
        {
            item.add_interceptor<RunOnUIThread>().intercept_all();
        }
    }
}