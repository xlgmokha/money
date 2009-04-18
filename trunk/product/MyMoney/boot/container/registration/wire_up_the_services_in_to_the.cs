using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.repositories;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Infrastructure.proxies;
using MoMoney.Infrastructure.transactions2;
using MoMoney.Tasks.application;

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
            registry.proxy<IBillingTasks, ServiceLayerConfiguration<IBillingTasks>>(
                () => new BillingTasks(Lazy.load<IBillRepository>(), Lazy.load<ICompanyRepository>()));

            registry.proxy<ICustomerTasks, ServiceLayerConfiguration<ICustomerTasks>>(
                () => new CustomerTasks(Lazy.load<IAccountHolderRepository>()));

            registry.proxy<IIncomeTasks, ServiceLayerConfiguration<IIncomeTasks>>(
                () => new IncomeTasks(Lazy.load<ICustomerTasks>(),
                                      Lazy.load<ICompanyRepository>(),
                                      Lazy.load<IIncomeRepository>()));

            wire_up_queries();
            wire_up_the_commands();
        }

        void wire_up_queries()
        {
            registry.proxy<IGetAllCompanysQuery, ServiceLayerConfiguration<IGetAllCompanysQuery>>(
                () => new GetAllCompanysQuery(Lazy.load<ICompanyRepository>()));
            registry.proxy<IGetAllBillsQuery, ServiceLayerConfiguration<IGetAllBillsQuery>>(
                () => new GetAllBillsQuery(Lazy.load<IBillRepository>()));
        }

        void wire_up_the_commands()
        {
            registry.proxy<IRegisterNewCompanyCommand, ServiceLayerConfiguration<IRegisterNewCompanyCommand>>(
                () => new RegisterNewCompanyCommand(Lazy.load<ICompanyFactory>()));
            registry.proxy<ISaveNewBillCommand, ServiceLayerConfiguration<ISaveNewBillCommand>>(
                () => new SaveNewBillCommand(Lazy.load<ICompanyRepository>(), Lazy.load<ICustomerTasks>()));
        }
    }

    internal class ServiceLayerConfiguration<T> : IConfiguration<IProxyBuilder<T>>
    {
        public void configure(IProxyBuilder<T> item)
        {
            item.add_interceptor(Lazy.load<IUnitOfWorkInterceptor>()).intercept_all();
        }
    }
}