using Castle.Core.Interceptor;
using Gorilla.Commons.Infrastructure.Logging;
using MoMoney.Presentation.Model.messages;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    public interface INotifyProgressInterceptor : IInterceptor {}

    public class NotifyProgressInterceptor : INotifyProgressInterceptor
    {
        readonly IEventAggregator broker;

        public NotifyProgressInterceptor(IEventAggregator broker)
        {
            this.broker = broker;
        }

        public void Intercept(IInvocation invocation)
        {
            this.log().debug("declaring type: {0}", invocation.GetConcreteMethodInvocationTarget().DeclaringType);
            this.log().debug("target type: {0}", invocation.TargetType);
            this.log().debug("proxy type: {0}", invocation.Proxy);
            this.log().debug("invocation target: {0}", invocation.InvocationTarget);
            broker.publish(new StartedRunningCommand(invocation.InvocationTarget));
            invocation.Proceed();
            broker.publish(new FinishedRunningCommand(invocation.InvocationTarget));
        }
    }
}