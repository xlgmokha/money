using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Presenters.reporting;
using MoMoney.Presentation.Resources;
using XPExplorerBar;

namespace MoMoney.Presentation.Presenters.Navigation
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
                    .when_clicked_execute(() => command.run<IViewAllBillsReportPresenter>())
                )
                .build();
        }
    }
}