using Castle.Core.Interceptor;
using momoney.presentation.model.eventing;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    public interface INotifyProgressInterceptor : IInterceptor
    {
    }

    public class NotifyProgressInterceptor : INotifyProgressInterceptor
    {
        readonly EventAggregator broker;

        public NotifyProgressInterceptor(EventAggregator broker)
        {
            this.broker = broker;
        }

        public void Intercept(IInvocation invocation)
        {
            broker.publish(new StartedRunningCommand(invocation.TargetType.Name));
            invocation.Proceed();
            broker.publish(new FinishedRunningCommand(invocation.TargetType.Name));
        }
    }
}