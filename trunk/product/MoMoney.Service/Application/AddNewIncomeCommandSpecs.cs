using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.accounting.financial_growth;
using MoMoney.Domain.Core;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Tasks.application;

namespace MoMoney.Service.Application
{
    public class AddNewIncomeCommandSpecs
    {
    }

    [Concern(typeof (AddNewIncomeCommand))]
    public abstract class when_adding_a_new_income : concerns_for<IAddNewIncomeCommand, AddNewIncomeCommand>
    {
        context c = () =>
                        {
                            notification = the_dependency<INotification>();
                            tasks = the_dependency<IIncomeTasks>();
                        };

        static protected INotification notification;
        static protected IIncomeTasks tasks;
    }

    [Concern(typeof (AddNewIncomeCommand))]
    public class when_the_same_income_has_already_been_added : when_adding_a_new_income
    {
        it should_inform_you_that_you_have_already_added_it =
            () => notification.was_told_to(x => x.notify("You have already submitted this income"));

        context c = () =>
                        {
                            var a_company = an<ICompany>();
                            var matching_income = an<IIncome>();
                            var today = new Date(2008, 12, 26);
                            var id = Guid.NewGuid();

                            income = new IncomeSubmissionDto
                                         {
                                             amount = 100.00,
                                             company_id = id,
                                             recieved_date = today,
                                         };

                            when_the(matching_income).is_asked_for(x => x.amount_tendered).it_will_return(100.as_money());
                            when_the(matching_income).is_asked_for(x => x.company).it_will_return(a_company);
                            when_the(matching_income).is_asked_for(x => x.date_of_issue).it_will_return(today);
                            when_the(a_company).is_asked_for(x => x.id).it_will_return(id);
                            when_the(tasks).is_told_to(x => x.retrive_all_income()).it_will_return(matching_income);
                        };

        because b = () => sut.run(income);

        static IncomeSubmissionDto income;
    }
}