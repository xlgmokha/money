using System.Collections.Generic;
using MoMoney.DTO;
using momoney.presentation.presenters;
using momoney.presentation.resources;
using MoMoney.Presentation.Views;
using MoMoney.Service.Contracts.Application;
using XPExplorerBar;

namespace MoMoney.Presentation.Presenters
{
    public class AddReportingTaskPane : IActionTaskPaneFactory
    {
        readonly IRunPresenterCommand command;

        public AddReportingTaskPane(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public Expando create()
        {
            return Build.task_pane()
                .named("Reports")
                .with_item(
                Build.task_pane_item()
                    .named("View All Bills")
                    .represented_by_icon(ApplicationIcons.ViewAllBillPayments)
                    .when_clicked_execute(() => command.run<ReportPresenter<IViewAllBillsReport, IEnumerable<BillInformationDTO>, IGetAllBillsQuery>>())
                )
                .with_item(
                Build.task_pane_item()
                    .named("View All Income")
                    .represented_by_icon(ApplicationIcons.ViewAllIncome)
                    .when_clicked_execute(() => command.run<ReportPresenter<IViewAllIncomeReport, IEnumerable<IncomeInformationDTO>, IGetAllIncomeQuery>>())
                )
                .build();
        }
    }
}