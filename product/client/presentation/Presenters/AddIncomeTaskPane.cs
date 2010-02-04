using momoney.presentation.presenters;
using momoney.presentation.resources;
using XPExplorerBar;

namespace MoMoney.Presentation.Presenters
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
                    .named("Add Income")
                    .represented_by_icon(ApplicationIcons.AddNewIncome)
                    .when_clicked_execute(() => command.run<AddNewIncomePresenter>())
                )
                .with_item(
                Build.task_pane_item()
                    .named("View All Income")
                    .represented_by_icon(ApplicationIcons.ViewAllIncome)
                    .when_clicked_execute(() => command.run<ViewIncomeHistoryPresenter>())
                )
                .build();
        }
    }
}