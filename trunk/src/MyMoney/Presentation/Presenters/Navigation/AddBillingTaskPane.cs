using MyMoney.Presentation.Presenters.billing;
using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Resources;
using XPExplorerBar;

namespace MyMoney.Presentation.Presenters.Navigation
{
    public class AddBillingTaskPane : IActionTaskPaneFactory
    {
        readonly IRunPresenterCommand command;

        public AddBillingTaskPane(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public Expando create()
        {
            return Build
                .task_pane()
                .named("Billing")
                .with_item(
                Build.task_pane_item()
                    .named("Add Bill Payments")
                    .represented_by_image(ApplicationImages.ReadingABill)
                    .when_clicked_execute(() => command.execute<IAddBillPaymentPresenter>())
                )
                .with_item(
                Build.task_pane_item()
                    .named("View All Bills")
                    .represented_by_image(ApplicationImages.ReadingABill)
                    .when_clicked_execute(() => command.execute<IViewAllBillsPresenter>())
                )
                .build();
        }
    }
}