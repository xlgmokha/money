using Castle.Core.Interceptor;
using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy;
using gorilla.commons.utility;

namespace momoney.service.infrastructure.threading
{
    public class RunOnUIThread : IInterceptor
    {
        readonly ISynchronizationContextFactory factory;

        public RunOnUIThread() : this(Lazy.load<ISynchronizationContextFactory>()) {}

        public RunOnUIThread(ISynchronizationContextFactory factory)
        {
            this.factory = factory;
        }

        public void Intercept(IInvocation invocation)
        {
            factory.create().run(new AnonymousCommand(invocation.Proceed));
        }
    }
}