using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;
using MoMoney.DTO;
using MoMoney.Service.Contracts.Application;
using Rhino.Mocks;

namespace MoMoney.Service.Application
{
    public class AddNewIncomeCommandSpecs {}

    [Concern(typeof (AddNewIncomeCommand))]
    public abstract class when_adding_a_new_income : concerns_for<IAddNewIncomeCommand, AddNewIncomeCommand>
    {
        context c = () =>
        {
            notification = the_dependency<Notification>();
            tasks = the_dependency<IGetTheCurrentCustomerQuery>();
            all_income = the_dependency<IIncomeRepository>();
            companies = the_dependency<ICompanyRepository>();
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
            var a_company = MockRepository.GenerateMock<Company>();
            var matching_income = MockRepository.GenerateMock<Income>();
            var today = new Date(2008, 12, 26);
            Id<Guid> id = Guid.NewGuid();

            income = new IncomeSubmissionDTO
                     {
                         amount = 100.00,
                         company_id = id,
                         recieved_date = today,
                     };

            when_the(matching_income).is_asked_for(x => x.amount_tendered).it_will_return(100);
            when_the(matching_income).is_asked_for(x => x.company).it_will_return(a_company);
            when_the(matching_income).is_asked_for(x => x.date_of_issue).it_will_return(today);
            when_the(a_company).is_asked_for(x => x.id).it_will_return(id);
            when_the(all_income).is_told_to(x => x.all()).it_will_return(matching_income);
        };

        because b = () => sut.run(income);

        static IncomeSubmissionDTO income;
    }
}