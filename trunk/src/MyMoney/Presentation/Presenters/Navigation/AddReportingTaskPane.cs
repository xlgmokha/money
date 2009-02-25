using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Presenters.reporting;
using MyMoney.Presentation.Resources;
using XPExplorerBar;

namespace MyMoney.Presentation.Presenters.Navigation
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
                    .when_clicked_execute(() => command.execute<IViewAllBillsReportPresenter>())
                )
                .build();
        }
    }
}