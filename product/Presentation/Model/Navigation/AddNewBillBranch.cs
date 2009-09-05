using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Model.Navigation
{
    public class AddNewBillBranch : IBranchVisitor
    {
        readonly IRunPresenterCommand command;

        public AddNewBillBranch(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public void visit(ITreeBranch item_to_visit)
        {
            item_to_visit.add_child("Add Bills", ApplicationIcons.AddIncome, () => command.run<IAddCompanyPresenter>());
        }
    }
}