using Castle.Core.Interceptor;
using gorilla.commons.Utility;

namespace momoney.service.infrastructure.threading
{
    public class RunOnBackgroundThreadInterceptor<CommandToExecute> : IInterceptor
        where CommandToExecute : DisposableCommand
    {
        readonly IBackgroundThreadFactory thread_factory;

        public RunOnBackgroundThreadInterceptor(IBackgroundThreadFactory thread_factory)
        {
            this.thread_factory = thread_factory;
        }

        public virtual void Intercept(IInvocation invocation)
        {
            using (thread_factory.create_for<CommandToExecute>())
            {
                invocation.Proceed();
            }
        }
    }
}