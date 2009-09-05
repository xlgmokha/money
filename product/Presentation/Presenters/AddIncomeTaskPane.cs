using MoMoney.Presentation.Presenters.income;
using MoMoney.Presentation.Resources;
using XPExplorerBar;

namespace MoMoney.Presentation.Presenters.Navigation
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
                    .represented_by_image(ApplicationImages.PayingABill)
                    .when_clicked_execute(() => command.run<IAddNewIncomePresenter>())
                )
                .with_item(
                Build.task_pane_item()
                    .named("View All Income")
                    .represented_by_image(ApplicationImages.PayingABill)
                    .when_clicked_execute(() => command.run<IViewIncomeHistoryPresenter>())
                )
                .build();
        }
    }
}