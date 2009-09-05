using MoMoney.Presentation.Resources;
using XPExplorerBar;

namespace MoMoney.Presentation.Presenters.Navigation
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
                    .represented_by_image(ApplicationImages.CompanyDetails)
                    .when_clicked_execute(() => command.run<IAddCompanyPresenter>()))
                .build();
        }
    }
}