using System;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.utility;
using MoMoney.Domain.Accounting;
using MoMoney.DTO;

namespace MoMoney.boot.container.registration
{
    class wire_up_the_mappers_in_to_the : Command
    {
        readonly DependencyRegistration registry;

        public wire_up_the_mappers_in_to_the(DependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.transient(typeof (Mapper<,>), typeof (AnonymousMapper<,>));
            //registry.singleton(()=> Mappers.bill_mapper);
            registry.singleton<Converter<Bill, BillInformationDTO>>(
                () => x =>
                      new BillInformationDTO
                      {
                          company_name = x.company_to_pay.name,
                          the_amount_owed = x.the_amount_owed.ToString(),
                          due_date = x.due_date.to_date_time(),
                      });
            registry.singleton<Converter<Company, CompanyDTO>>(() => x => new CompanyDTO {id = x.id, name = x.name});

            registry.singleton<Converter<Income, IncomeInformationDTO>>(
                () => x => new IncomeInformationDTO
                           {
                               amount = x.amount_tendered.to_string(),
                               company = x.company.to_string(),
                               recieved_date = x.date_of_issue.to_string(),
                           });
        }
    }
}