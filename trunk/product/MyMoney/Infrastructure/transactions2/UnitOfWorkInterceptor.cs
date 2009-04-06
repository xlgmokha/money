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
        readonly IUnitOfWorkFactory factory;

        public UnitOfWorkInterceptor(IEventAggregator broker, IUnitOfWorkFactory factory)
        {
            this.broker = broker;
            this.factory = factory;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var unit_of_work = factory.create())
            {
                invocation.Proceed();
                if (unit_of_work.is_dirty())
                {
                    unit_of_work.commit();
                    broker.publish<UnsavedChangesEvent>();
                }
            }
        }
    }
}