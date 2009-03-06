using Castle.Core.Interceptor;
using MoMoney.Infrastructure.eventing;

namespace MoMoney.Infrastructure.interceptors
{
    public interface IRaiseEventInterceptor<Event> : IInterceptor where Event : IEvent, new()
    {}

    public class raise_event_interceptor<Event> : IRaiseEventInterceptor<Event> where Event : IEvent, new()
    {
        private readonly IEventAggregator broker;

        public raise_event_interceptor(IEventAggregator broker)
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