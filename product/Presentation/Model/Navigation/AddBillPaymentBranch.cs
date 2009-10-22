using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Model.Navigation
{
    public class AddBillPaymentBranch : IBranchVisitor
    {
        readonly IRunPresenterCommand command;

        public AddBillPaymentBranch(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public void visit(ITreeBranch item_to_visit)
        {
            item_to_visit.add_child("Bill Payments", ApplicationIcons.AddIncome, () => command.run<IAddBillPaymentPresenter>());
        }
    }
}