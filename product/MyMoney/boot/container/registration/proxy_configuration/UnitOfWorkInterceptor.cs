using Castle.Core.Interceptor;
using Gorilla.Commons.Infrastructure.Eventing;
using Gorilla.Commons.Utility.Core;
using MoMoney.Service.Contracts.Infrastructure.Transactions;
using MoMoney.Service.Infrastructure.Transactions;

namespace MoMoney.boot.container.registration.proxy_configuration
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
                broker.publish<ICallback<IUnitOfWork>>(x => x.run(unit_of_work));
                unit_of_work.commit();
            }
        }
    }
}