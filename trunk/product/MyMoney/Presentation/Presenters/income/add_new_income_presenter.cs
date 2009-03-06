using System.Linq;
using MoMoney.Domain.accounting.financial_growth;
using MoMoney.Domain.Core;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.income;
using MoMoney.Tasks.application;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.income
{
    public interface IAddNewIncomePresenter : IContentPresenter
    {
        void submit_new(income_submission_dto income);
    }

    public class add_new_income_presenter : IAddNewIncomePresenter
    {
        private readonly IAddNewIncomeView view;
        private readonly IIncomeTasks tasks;

        public add_new_income_presenter(IAddNewIncomeView view, IIncomeTasks tasks)
        {
            this.view = view;
            this.tasks = tasks;
        }

        public void run()
        {
            view.attach_to(this);
            view.display(tasks.all_companys());
            view.display(tasks.retrive_all_income().map_all_using(x => map_from(x)));
        }

        public void submit_new(income_submission_dto income)
        {
            if (similar_income_has_been_submitted(income))
            {
                view.notify("You have already submitted this income");
            }
            tasks.add_new(income);
            view.display(tasks.retrive_all_income().map_all_using(x => map_from(x)));
        }

        private bool similar_income_has_been_submitted(income_submission_dto income)
        {
            if (tasks.retrive_all_income().Count() == 0) return false;
            return tasks
                .retrive_all_income()
                .where(x => x.amount_tendered.Equals(income.amount.as_money()))
                .where(x => x.company.Equals(income.company))
                .where(x => x.date_of_issue.Equals(income.recieved_date.as_a_date()))
                .Count() > 0 ;
        }

        private static income_information_dto map_from(IIncome x)
        {
            return new income_information_dto
                       {
                           amount = x.amount_tendered.to_string(),
                           company = x.company.to_string(),
                           recieved_date = x.date_of_issue.to_string(),
                       };
        }

        IDockedContentView IContentPresenter.View
        {
            get { return view; }
        }
    }
}