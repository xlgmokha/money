using momoney.presentation.presenters;
using momoney.presentation.resources;
using XPExplorerBar;

namespace MoMoney.Presentation.Presenters
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
                    .represented_by_icon(ApplicationIcons.AddBillPayment)
                    .when_clicked_execute(() => command.run<AddBillPaymentPresenter>())
                )
                .with_item(
                Build.task_pane_item()
                    .named("View All Bills Payments")
                    .represented_by_icon(ApplicationIcons.ViewAllBillPayments)
                    .when_clicked_execute(() => command.run<ViewAllBillsPresenter>())
                )
                .build();
        }
    }
}