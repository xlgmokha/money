using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters.Navigation;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Resources;
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
                    .represented_by_image(ApplicationImages.ReadingABill)
                    .when_clicked_execute(() => command.run<IReportPresenter<IViewAllBillsReport, IEnumerable<BillInformationDTO>, IGetAllBillsQuery>>())
                )
                .build();
        }
    }
}