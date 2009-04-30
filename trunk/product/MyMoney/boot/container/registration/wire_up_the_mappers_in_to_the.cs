using System;
using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.Accounting;
using MoMoney.DTO;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_mappers_in_to_the : ICommand
    {
        readonly IDependencyRegistration registry;

        public wire_up_the_mappers_in_to_the(IDependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.transient(typeof (IMapper<,>), typeof (Map<,>));
            registry.singleton<Converter<IBill, BillInformationDTO>>(
                () => x => new BillInformationDTO
                               {
                                   company_name = x.company_to_pay.name,
                                   the_amount_owed = x.the_amount_owed.ToString(),
                                   due_date = x.due_date.to_date_time(),
                               });
            registry.singleton<Converter<ICompany, CompanyDTO>>(() => x => new CompanyDTO {id = x.id, name = x.name});

            registry.singleton<Converter<IIncome, IncomeInformationDTO>>(
                () => x => new IncomeInformationDTO
                               {
                                   amount = x.amount_tendered.to_string(),
                                   company = x.company.to_string(),
                                   recieved_date = x.date_of_issue.to_string(),
                               });
        }
    }
}