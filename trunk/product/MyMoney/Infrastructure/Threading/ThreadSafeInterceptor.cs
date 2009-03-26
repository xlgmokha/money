using Castle.Core.Interceptor;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public interface IThreadSafeInterceptor : IInterceptor
    {
    }

    public class ThreadSafeInterceptor : IThreadSafeInterceptor
    {
        readonly ISynchronizationContextFactory factory;

        public ThreadSafeInterceptor() : this(Lazy.load<ISynchronizationContextFactory>())
        {
        }

        public ThreadSafeInterceptor(ISynchronizationContextFactory factory)
        {
            this.factory = factory;
        }

        public void Intercept(IInvocation invocation)
        {
            factory.create().run(new ActionCommand(invocation.Proceed));
        }
    }
}