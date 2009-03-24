using System;
using MoMoney.DataAccess.core;
using MoMoney.Domain.repositories;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.interceptors;
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
            registry.proxy(new ServiceLayerConfiguration<IBillingTasks>(
                               x =>
                                   {
                                       x.register_new_company(null);
                                       x.save_a_new_bill_using(null);
                                   }
                               ),
                           () =>
                           new BillingTasks(Lazy.load<IBillRepository>(), Lazy.load<ICompanyRepository>(),
                                            Lazy.load<ICustomerTasks>()));

            registry.proxy(
                new ServiceLayerConfiguration<ICustomerTasks>(x => x.get_the_current_customer()),
                () => new CustomerTasks(Lazy.load<IDatabaseGateway>()));

            registry.proxy(
                new ServiceLayerConfiguration<IIncomeTasks>(x => x.add_new(null)),
                () => new IncomeTasks(Lazy.load<IDatabaseGateway>(), Lazy.load<ICustomerTasks>()));
        }
    }

    internal class ServiceLayerConfiguration<T> : IConfiguration<IProxyBuilder<T>>
    {
        readonly Action<T> configure_it;

        public ServiceLayerConfiguration(Action<T> configure_it)
        {
            this.configure_it = configure_it;
        }

        public void configure(IProxyBuilder<T> item)
        {
            configure_it(item.add_interceptor(Lazy.load<IUnitOfWorkInterceptor>()).InterceptOn);
        }
    }
}