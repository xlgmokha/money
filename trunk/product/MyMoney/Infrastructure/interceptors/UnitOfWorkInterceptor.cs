using Castle.Core.Interceptor;
using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.transactions;
using MoMoney.Presentation.Model.messages;

namespace MoMoney.Infrastructure.interceptors
{
    public interface IUnitOfWorkInterceptor : IInterceptor
    {
    }

    public class UnitOfWorkInterceptor : IUnitOfWorkInterceptor
    {
        readonly IUnitOfWorkRegistry registry;
        readonly IEventAggregator broker;

        public UnitOfWorkInterceptor(IUnitOfWorkRegistry registry, IEventAggregator broker)
        {
            this.registry = registry;
            this.broker = broker;
        }

        public void Intercept(IInvocation invocation)
        {
            using (registry)
            {
                invocation.Proceed();
                if (registry.has_changes_to_commit())
                {
                    registry.commit_all();
                    broker.publish<unsaved_changes_event>();
                }
            }
        }
    }
}