using System.Collections.Generic;
using jpboodhoo.bdd.contexts;
using MyMoney.Domain.accounting.billing;
using MyMoney.Domain.accounting.financial_growth;
using MyMoney.Domain.Core;
using MyMoney.Presentation.Presenters.income.dto;
using MyMoney.Presentation.Views.income;
using MyMoney.Tasks.application;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Presenters.income
{
    [Concern(typeof (add_new_income_presenter))]
    public abstract class behaves_like_add_new_income_presenter : concerns_for<IAddNewIncomePresenter, add_new_income_presenter>
    {
        //public override IAddNewIncomePresenter create_sut()
        //{
        //    return new add_new_income_presenter(view, tasks);
        //}

        context c = () =>
                        {
                            view = the_dependency<IAddNewIncomeView>();
                            tasks = the_dependency<IIncomeTasks>();
                        };

        protected static IIncomeTasks tasks;
        protected static IAddNewIncomeView view;
    }

    public class when_depositing_new_income_from_a_company : behaves_like_add_new_income_presenter
    {
        it should_add_the_income_to_the_account_holders_account = () => tasks.was_told_to(x => x.add_new(income));

        context c = () =>
                        {
                            income = new income_submission_dto {};
                            when_the(tasks).is_told_to(x => x.retrive_all_income()).it_will_return_nothing();
                        };

        because b = () => sut.submit_new(income);

        static income_submission_dto income;
    }

    public class when_loading_the_add_new_income_screen : behaves_like_add_new_income_presenter
    {
        it should_display_a_list_of_all_the_registered_company_to_select = () => view.was_told_to( x => x.display(companys));

        it should_bind_a_presenter_to_the_screen = () => view.was_told_to(x => x.attach_to(sut));

        context c = () =>
                        {
                            companys = new List<ICompany>();
                            tasks.is_told_to(x => x.all_companys()).it_will_return(companys);
                        };

        because b = () => sut.run();

        static List<ICompany> companys;
    }

    [Concern(typeof (add_new_income_presenter))]
    public class when_attempting_to_submit_the_same_income_more_than_once : behaves_like_add_new_income_presenter
    {
        it should_inform_you_that_you_have_already_added_it =
            () => view.was_told_to(x => x.notify("You have already submitted this income"));

        context c = () =>
                        {
                            var a_company = an<ICompany>();
                            var matching_income = an<IIncome>();
                            var today = new Date(2008, 12, 26);

                            income = new income_submission_dto
                                         {
                                             amount = 100.00,
                                             company = a_company,
                                             recieved_date = today,
                                         };

                            when_the(matching_income).is_asked_for(x => x.amount_tendered).it_will_return(100.as_money());
                            when_the(matching_income).is_asked_for(x => x.company).it_will_return(a_company);
                            when_the(matching_income).is_asked_for(x => x.date_of_issue).it_will_return(today);
                            when_the(tasks).is_told_to(x => x.retrive_all_income()).it_will_return(matching_income);
                        };

        because b = () => sut.submit_new(income);

        static income_submission_dto income;
    }
}