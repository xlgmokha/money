using Castle.Core.Interceptor;
using Gorilla.Commons.Infrastructure.Eventing;

namespace MoMoney.Infrastructure.interceptors
{
    public interface IRaiseEventInterceptor<Event> : IInterceptor where Event : IEvent, new()
    {
    }

    public class RaiseEventInterceptor<Event> : IRaiseEventInterceptor<Event> where Event : IEvent, new()
    {
        readonly IEventAggregator broker;

        public RaiseEventInterceptor(IEventAggregator broker)
        {
            this.broker = broker;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            broker.publish(new Event());
        }
    }
}