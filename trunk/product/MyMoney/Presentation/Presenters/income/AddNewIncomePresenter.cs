using System.Linq;
using MoMoney.Domain.accounting.financial_growth;
using MoMoney.Domain.Core;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Presentation.Views.income;
using MoMoney.Tasks.application;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.income
{
    public interface IAddNewIncomePresenter : IContentPresenter
    {
        void submit_new(IncomeSubmissionDto income);
    }

    public class AddNewIncomePresenter : ContentPresenter<IAddNewIncomeView>, IAddNewIncomePresenter
    {
        readonly IIncomeTasks tasks;

        public AddNewIncomePresenter(IAddNewIncomeView view, IIncomeTasks tasks) : base(view)
        {
            this.tasks = tasks;
        }

        public override void run()
        {
            view.attach_to(this);
            view.display(tasks.all_companys());
            view.display(tasks.retrive_all_income().map_all_using(x => map_from(x)));
        }

        public void submit_new(IncomeSubmissionDto income)
        {
            if (similar_income_has_been_submitted(income))
            {
                view.notify("You have already submitted this income");
            }
            tasks.add_new(income);
            view.display(tasks.retrive_all_income().map_all_using(x => map_from(x)));
        }

        bool similar_income_has_been_submitted(IncomeSubmissionDto income)
        {
            if (tasks.retrive_all_income().Count() == 0) return false;
            return tasks
                       .retrive_all_income()
                       .where(x => x.amount_tendered.Equals(income.amount.as_money()))
                       .where(x => x.company.id.Equals(income.company_id))
                       .where(x => x.date_of_issue.Equals(income.recieved_date.as_a_date()))
                       .Count() > 0;
        }

        static income_information_dto map_from(IIncome x)
        {
            return new income_information_dto
                       {
                           amount = x.amount_tendered.to_string(),
                           company = x.company.to_string(),
                           recieved_date = x.date_of_issue.to_string(),
                       };
        }
    }
}