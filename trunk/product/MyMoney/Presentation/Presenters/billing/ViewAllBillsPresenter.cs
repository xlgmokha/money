using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.billing;
using MoMoney.Presentation.Views.core;
using MoMoney.Tasks.application;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.billing
{
    public interface IViewAllBillsPresenter : IContentPresenter
    {
    }

    public class ViewAllBillsPresenter : IViewAllBillsPresenter
    {
        readonly IViewAllBills view;
        readonly IBillingTasks tasks;

        public ViewAllBillsPresenter(IViewAllBills view, IBillingTasks tasks)
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
                    x => new bill_information_dto
                             {
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