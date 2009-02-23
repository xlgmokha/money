using Castle.Core.Interceptor;
using MyMoney.Infrastructure.eventing;
using MyMoney.Infrastructure.transactions;
using MyMoney.Presentation.Model.messages;

namespace MyMoney.Infrastructure.interceptors
{
    public interface IUnitOfWorkInterceptor : IInterceptor
    {}

    public class unit_of_work_interceptor : IUnitOfWorkInterceptor
    {
        private readonly IUnitOfWorkRegistry registry;
        private readonly IEventAggregator broker;

        public unit_of_work_interceptor(IUnitOfWorkRegistry registry, IEventAggregator broker)
        {
            this.registry = registry;
            this.broker = broker;
        }

        public void Intercept(IInvocation invocation)
        {
            using (registry) {
                invocation.Proceed();
                registry.commit_all();
                broker.publish<unsaved_changes_event>();
            }
        }
    }
}