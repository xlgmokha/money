using MyMoney.Presentation.Core;
using MyMoney.Presentation.Presenters.billing.dto;
using MyMoney.Presentation.Views.billing;
using MyMoney.Presentation.Views.core;
using MyMoney.Tasks.application;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Presenters.billing
{
    public interface IViewAllBillsPresenter : IContentPresenter
    {}

    public class view_all_bills_presenter : IViewAllBillsPresenter
    {
        private readonly IViewAllBills view;
        private readonly IBillingTasks tasks;

        public view_all_bills_presenter(IViewAllBills view, IBillingTasks tasks)
        {
            this.view = view;
            this.tasks = tasks;
        }

        public void run()
        {
            view.display(
                tasks
                    .all_bills()
                    .map_all_using(
                    x => new bill_information_dto {
                                                      company_name = x.company_to_pay.name,
                                                      the_amount_owed = x.the_amount_owed.ToString(),
                                                      due_date = x.due_date.to_date_time(),
                                                  }));
        }

        IDockedContentView IContentPresenter.View
        {
            get { return view; }
        }
    }
}