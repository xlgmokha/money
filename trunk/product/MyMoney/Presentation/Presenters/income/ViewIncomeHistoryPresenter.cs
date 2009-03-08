using System.Linq;
using MoMoney.Domain.accounting.financial_growth;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.income;
using MoMoney.Tasks.application;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.income
{
    public interface IViewIncomeHistoryPresenter : IContentPresenter
    {
    }

    public class ViewIncomeHistoryPresenter : IViewIncomeHistoryPresenter
    {
        private readonly IViewIncomeHistory view;
        private readonly IIncomeTasks tasks;

        public ViewIncomeHistoryPresenter(IViewIncomeHistory view, IIncomeTasks tasks)
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