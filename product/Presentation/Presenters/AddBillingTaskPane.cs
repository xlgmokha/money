using MoMoney.Presentation.Presenters.billing;
using MoMoney.Presentation.Winforms.Resources;
using XPExplorerBar;

namespace MoMoney.Presentation.Presenters.Navigation
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
                    .when_clicked_execute(() => command.run<IAddBillPaymentPresenter>())
                )
                .with_item(
                Build.task_pane_item()
                    .named("View All Bills")
                    .represented_by_image(ApplicationImages.ReadingABill)
                    .when_clicked_execute(() => command.run<IViewAllBillsPresenter>())
                )
                .build();
        }
    }
}