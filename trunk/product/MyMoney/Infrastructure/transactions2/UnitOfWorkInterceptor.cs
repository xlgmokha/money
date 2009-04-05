using Castle.Core.Interceptor;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Model.messages;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IUnitOfWorkInterceptor : IInterceptor
    {
    }

    public class UnitOfWorkInterceptor : IUnitOfWorkInterceptor
    {
        readonly IEventAggregator broker;
        readonly ISessionFactory factory;

        public UnitOfWorkInterceptor(IEventAggregator broker, ISessionFactory factory)
        {
            this.broker = broker;
            this.factory = factory;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var session = factory.create())
            {
                invocation.Proceed();
                if (session.is_dirty())
                {
                    session.flush();
                    broker.publish<UnsavedChangesEvent>();
                }
            }
        }
    }
}