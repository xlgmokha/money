using MyMoney.Presentation.Presenters.billing;
using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Resources;

namespace MyMoney.Presentation.Model.Navigation.branches
{
    public class add_bill_payment_branch : IBranchVisitor
    {
        private readonly IRunThe<IAddBillPaymentPresenter> command;

        public add_bill_payment_branch(IRunThe<IAddBillPaymentPresenter> command)
        {
            this.command = command;
        }

        public void visit(ITreeBranch item_to_visit)
        {
            item_to_visit.add_child("Bill Payments", ApplicationIcons.AddIncome, command);
        }
    }
}