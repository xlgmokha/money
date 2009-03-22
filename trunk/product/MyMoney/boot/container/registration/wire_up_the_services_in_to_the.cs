using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.proxies;
using MoMoney.Presentation.Context;
using MoMoney.Tasks.application;
using MoMoney.Utility.Core;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_services_in_to_the : ICommand
    {
        readonly IDependencyRegistration registry;

        public wire_up_the_services_in_to_the(IDependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.singleton<the_application_context, the_application_context>();
            //registry.proxy<IBillingTasks>(new ServiceLayerConfiguration<IBillingTasks>(), () => { return null; });
        }
    }

    internal class ServiceLayerConfiguration<T> : IConfiguration<IProxyBuilder<IBillingTasks>>
    {
        public void configure(IProxyBuilder<IBillingTasks> item)
        {
            //item.add_interceptor<UnitOfWorkInterceptor>()
        }
    }
}