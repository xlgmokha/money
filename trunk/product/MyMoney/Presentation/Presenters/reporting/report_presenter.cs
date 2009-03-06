using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.billing;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.reporting;
using MoMoney.Tasks.application;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.reporting
{
    public interface IViewAllBillsReportPresenter : IContentPresenter
    {
    }

    public class report_presenter : IViewAllBillsReportPresenter
    {
        private readonly IReportViewer view;
        private readonly IViewAllBillsReport report;
        private readonly IBillingTasks tasks;

        public report_presenter(IReportViewer view, IViewAllBillsReport report, IBillingTasks tasks)
        {
            this.view = view;
            this.tasks = tasks;
            this.report = report;
        }

        public void run()
        {
            report.bind_to(tasks.all_bills().map_all_using(x => map_from(x)));
            view.display(report);
        }

        private bill_information_dto map_from(IBill x)
        {
            return new bill_information_dto
                       {
                           company_name = x.company_to_pay.name,
                           due_date = x.due_date.to_date_time(),
                           the_amount_owed = x.the_amount_owed.to_string()
                       };
        }

        IDockedContentView IContentPresenter.View
        {
            get { return view; }
        }
    }
}