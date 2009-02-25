using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.Navigation;
using XPExplorerBar;

namespace MyMoney.Presentation.Presenters.Navigation
{
    public class company_task_presenter : IActionTaskPresenter
    {
        readonly IRunPresenterCommand command;

        public company_task_presenter(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public void run(IActionsTaskView view)
        {
            view.Add(create_expando());
        }

        Expando create_expando()
        {
            return Build.Expando()
                .Named("Company")
                .WithItem(
                Build.ExpandoItem()
                    .Named("Add Company")
                    .RepresentedByImage(ApplicationImages.ReadingABill)
                    .WhenClickedExecute(() => command.execute<IAddCompanyPresenter>()))
                .Build();
        }
    }
}