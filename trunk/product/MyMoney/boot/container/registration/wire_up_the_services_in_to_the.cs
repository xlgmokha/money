using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Utility.Core;
using MoMoney.boot.container.registration.proxy_configuration;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.repositories;
using MoMoney.Service.Application;

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
            registry.proxy<ICustomerTasks, ServiceLayerConfiguration<ICustomerTasks>>(
                () => new CustomerTasks(Lazy.load<IAccountHolderRepository>()));

            wire_up_queries();
            wire_up_the_commands();
        }

        void wire_up_queries()
        {
            registry.proxy<IGetAllCompanysQuery, ServiceLayerConfiguration<IGetAllCompanysQuery>>(
                () => new GetAllCompanysQuery(Lazy.load<ICompanyRepository>()));
            registry.proxy<IGetAllBillsQuery, ServiceLayerConfiguration<IGetAllBillsQuery>>(
                () => new GetAllBillsQuery(Lazy.load<IBillRepository>()));
            registry.proxy<IGetAllIncomeQuery, ServiceLayerConfiguration<IGetAllIncomeQuery>>(
                () => new GetAllIncomeQuery(Lazy.load<IIncomeRepository>()));
        }

        void wire_up_the_commands()
        {
            registry.proxy<IRegisterNewCompanyCommand, ServiceLayerConfiguration<IRegisterNewCompanyCommand>>(
                () =>
                new RegisterNewCompanyCommand(Lazy.load<ICompanyFactory>(), Lazy.load<INotification>(),
                                              Lazy.load<ICompanyRepository>()));
            registry.proxy<ISaveNewBillCommand, ServiceLayerConfiguration<ISaveNewBillCommand>>(
                () => new SaveNewBillCommand(Lazy.load<ICompanyRepository>(), Lazy.load<ICustomerTasks>()));

            registry.proxy<IAddNewIncomeCommand, ServiceLayerConfiguration<IAddNewIncomeCommand>>(
                () =>
                new AddNewIncomeCommand(Lazy.load<ICustomerTasks>(), Lazy.load<INotification>(),
                                        Lazy.load<IIncomeRepository>(), Lazy.load<ICompanyRepository>()));
        }
    }
}