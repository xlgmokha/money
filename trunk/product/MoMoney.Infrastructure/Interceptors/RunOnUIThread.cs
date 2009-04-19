using Castle.Core.Interceptor;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.interceptors;

namespace MoMoney.Infrastructure.Interceptors
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