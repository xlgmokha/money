using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Utility.Core;
using MoMoney.boot.container.registration.proxy_configuration;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;
using MoMoney.DTO;
using MoMoney.Service.Application;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.boot.container.registration
{
    class wire_up_the_services_in_to_the : ICommand
    {
        readonly IDependencyRegistration registry;

        public wire_up_the_services_in_to_the(IDependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.proxy<IGetTheCurrentCustomerQuery, ServiceLayerConfiguration<IGetTheCurrentCustomerQuery>>(
                () => new GetTheCurrentCustomerQuery(Lazy.load<IAccountHolderRepository>()));

            wire_up_queries();
            wire_up_the_commands();
        }

        void wire_up_queries()
        {
            registry.proxy<IGetAllCompanysQuery, ServiceLayerConfiguration<IGetAllCompanysQuery>>(
                () =>
                new GetAllCompanysQuery(Lazy.load<ICompanyRepository>(), Lazy.load<IMapper<ICompany, CompanyDTO>>()));
            registry.proxy<IGetAllBillsQuery, ServiceLayerConfiguration<IGetAllBillsQuery>>(
                () =>
                new GetAllBillsQuery(Lazy.load<IBillRepository>(), Lazy.load<IMapper<IBill, BillInformationDTO>>()));
            registry.proxy<IGetAllIncomeQuery, ServiceLayerConfiguration<IGetAllIncomeQuery>>(
                () =>
                new GetAllIncomeQuery(Lazy.load<IIncomeRepository>(),
                                      Lazy.load<IMapper<IIncome, IncomeInformationDTO>>()));
        }

        void wire_up_the_commands()
        {
            registry.proxy<IRegisterNewCompanyCommand, ServiceLayerConfiguration<IRegisterNewCompanyCommand>>(
                () =>
                new RegisterNewCompanyCommand(Lazy.load<ICompanyFactory>(), Lazy.load<INotification>(),
                                              Lazy.load<ICompanyRepository>()));
            registry.proxy<ISaveNewBillCommand, ServiceLayerConfiguration<ISaveNewBillCommand>>(
                () => new SaveNewBillCommand(Lazy.load<ICompanyRepository>(), Lazy.load<IGetTheCurrentCustomerQuery>()));

            registry.proxy<IAddNewIncomeCommand, ServiceLayerConfiguration<IAddNewIncomeCommand>>(
                () =>
                new AddNewIncomeCommand(Lazy.load<IGetTheCurrentCustomerQuery>(), Lazy.load<INotification>(),
                                        Lazy.load<IIncomeRepository>(), Lazy.load<ICompanyRepository>()));
        }
    }
}