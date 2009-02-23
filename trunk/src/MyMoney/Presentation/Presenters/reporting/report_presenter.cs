using MyMoney.Domain.accounting.billing;
using MyMoney.Presentation.Core;
using MyMoney.Presentation.Presenters.billing.dto;
using MyMoney.Presentation.Views.billing;
using MyMoney.Presentation.Views.core;
using MyMoney.Presentation.Views.reporting;
using MyMoney.Tasks.application;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Presenters.reporting
{
    public interface IViewAllBillsReportPresenter : IContentPresenter
    {
    }

    public class report_presenter : IViewAllBillsReportPresenter
    {
        private readonly IReportView view;
        private readonly IViewAllBillsReport report;
        private readonly IBillingTasks tasks;

        public report_presenter(IReportView view, IViewAllBillsReport report, IBillingTasks tasks)
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