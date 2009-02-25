using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Presenters.income;
using MyMoney.Presentation.Resources;
using XPExplorerBar;

namespace MyMoney.Presentation.Presenters.Navigation
{
    public class AddIncomeTaskPane : IActionTaskPaneFactory
    {
        readonly IRunPresenterCommand command;

        public AddIncomeTaskPane(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public Expando create()
        {
            return Build.task_pane()
                .named("Income")
                .with_item(
                Build.task_pane_item()
                    .named("Add New Income")
                    .represented_by_image(ApplicationImages.ReadingABill)
                    .when_clicked_execute(() => command.execute<IAddNewIncomePresenter>())
                )
                .with_item(
                Build.task_pane_item()
                    .named("View All Income")
                    .represented_by_image(ApplicationImages.ReadingABill)
                    .when_clicked_execute(() => command.execute<IViewIncomeHistoryPresenter>())
                )
                .build();
        }
    }
}