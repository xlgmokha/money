using Castle.Core.Interceptor;
using MyMoney.Infrastructure.eventing;
using MyMoney.Infrastructure.transactions;
using MyMoney.Presentation.Model.messages;

namespace MyMoney.Infrastructure.interceptors
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