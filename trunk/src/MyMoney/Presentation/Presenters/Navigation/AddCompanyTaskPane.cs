using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Resources;
using XPExplorerBar;

namespace MyMoney.Presentation.Presenters.Navigation
{
    public class AddCompanyTaskPane : IActionTaskPaneFactory
    {
        readonly IRunPresenterCommand command;

        public AddCompanyTaskPane(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public Expando create()
        {
            return Build.task_pane()
                .named("Company")
                .with_item(
                Build.task_pane_item()
                    .named("Add Company")
                    .represented_by_image(ApplicationImages.ReadingABill)
                    .when_clicked_execute(() => command.execute<IAddCompanyPresenter>()))
                .build();
        }
    }
}