using System;
using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;
using MoMoney.DTO;
using MoMoney.Service.Application;

namespace tests.unit.client.service.application
{
    public class AddNewIncomeCommandSpecs
    {
        [Concern(typeof (AddNewIncomeCommand))]
        public abstract class when_adding_a_new_income : runner<AddNewIncomeCommand>
        {
            context c = () =>
            {
                notification = dependency<Notification>();
                tasks = dependency<IGetTheCurrentCustomerQuery>();
                all_income = dependency<IIncomeRepository>();
                companies = dependency<ICompanyRepository>();
            };

            static protected Notification notification;
            static protected IGetTheCurrentCustomerQuery tasks;
            static protected IIncomeRepository all_income;
            static protected ICompanyRepository companies;
        }

        [Concern(typeof (AddNewIncomeCommand))]
        public class when_the_same_income_has_already_been_added : when_adding_a_new_income
        {
            it should_inform_you_that_you_have_already_added_it =
                () => notification.was_told_to(x => x.notify("You have already submitted this income"));

            context c = () =>
            {
                var a_company = an<Company>();
                var matching_income = an<Income>();
                var today = new Date(2008, 12, 26);
                Id<Guid> id = Guid.NewGuid();

                income = new IncomeSubmissionDTO
                         {
                             amount = 100.00,
                             company_id = id,
                             recieved_date = today,
                         };

                matching_income.is_asked_for(x => x.amount_tendered).it_will_return(100);
                matching_income.is_asked_for(x => x.company).it_will_return(a_company);
                matching_income.is_asked_for(x => x.date_of_issue).it_will_return(today);
                a_company.is_asked_for(x => x.id).it_will_return(id);
                all_income.is_told_to(x => x.all()).it_will_return(matching_income);
            };

            because b = () => sut.run(income);

            static IncomeSubmissionDTO income;
        }
    }
}