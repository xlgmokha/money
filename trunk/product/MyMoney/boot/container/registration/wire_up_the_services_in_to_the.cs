using System;
using MoMoney.DataAccess.core;
using MoMoney.Domain.repositories;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Infrastructure.proxies;
using MoMoney.Tasks.application;
using MoMoney.Utility.Core;
using IUnitOfWorkInterceptor=MoMoney.Infrastructure.transactions2.IUnitOfWorkInterceptor;

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
            registry.proxy(new ServiceLayerConfiguration<IBillingTasks>(
                               x =>
                                   {
                                       //x.register_new_company(null);
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
                () => new IncomeTasks(Lazy.load<ICustomerTasks>(),
                                      Lazy.load<ICompanyRepository>(),
                                      Lazy.load<IIncomeRepository>()));
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
            var selector = item.add_interceptor(Lazy.load<IUnitOfWorkInterceptor>());
            selector.intercept_all();
            //configure_it(selector.intercept_on);
        }
    }
}