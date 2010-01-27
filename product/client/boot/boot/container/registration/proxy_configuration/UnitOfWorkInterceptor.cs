using Castle.Core.Interceptor;
using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Eventing;
using momoney.service.infrastructure.transactions;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    public interface IUnitOfWorkInterceptor : IInterceptor {}

    public class UnitOfWorkInterceptor : IUnitOfWorkInterceptor
    {
        readonly EventAggregator broker;
        readonly IUnitOfWorkFactory factory;

        public UnitOfWorkInterceptor(EventAggregator broker, IUnitOfWorkFactory factory)
        {
            this.broker = broker;
            this.factory = factory;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var unit_of_work = factory.create())
            {
                invocation.Proceed();
                broker.publish<Callback<IUnitOfWork>>(x => x.run(unit_of_work));
                unit_of_work.commit();
            }
        }
    }
}