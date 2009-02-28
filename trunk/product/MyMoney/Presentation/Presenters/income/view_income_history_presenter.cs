using System.Linq;
using MyMoney.Domain.accounting.financial_growth;
using MyMoney.Presentation.Core;
using MyMoney.Presentation.Presenters.income.dto;
using MyMoney.Presentation.Views.core;
using MyMoney.Presentation.Views.income;
using MyMoney.Tasks.application;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Presenters.income
{
    public interface IViewIncomeHistoryPresenter : IContentPresenter
    {
    }

    public class view_income_history_presenter : IViewIncomeHistoryPresenter
    {
        private readonly IViewIncomeHistory view;
        private readonly IIncomeTasks tasks;

        public view_income_history_presenter(IViewIncomeHistory view, IIncomeTasks tasks)
        {
            this.view = view;
            this.tasks = tasks;
        }

        public void run()
        {
            view.display(tasks.retrive_all_income().map_all_using(x => map_from(x)));
        }

        private income_information_dto map_from(IIncome x)
        {
            return new income_information_dto
                       {
                           amount = x.amount_tendered.ToString(),
                           company = x.company.ToString(),
                           recieved_date = x.date_of_issue.ToString(),
                       };
        }

        IDockedContentView IContentPresenter.View
        {
            get { return view; }
        }
    }
}