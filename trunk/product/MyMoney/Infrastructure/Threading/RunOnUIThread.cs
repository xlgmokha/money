using Castle.Core.Interceptor;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public class RunOnUIThread : IInterceptor
    {
        readonly ISynchronizationContextFactory factory;

        public RunOnUIThread() : this(Lazy.load<ISynchronizationContextFactory>())
        {
        }

        public RunOnUIThread(ISynchronizationContextFactory factory)
        {
            this.factory = factory;
        }

        public void Intercept(IInvocation invocation)
        {
            factory.create().run(new ActionCommand(invocation.Proceed));
        }
    }
}