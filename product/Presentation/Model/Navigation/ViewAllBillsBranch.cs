using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Model.Navigation
{
    public class ViewAllBillsBranch : IBranchVisitor
    {
        private readonly IRunThe<IViewAllBillsPresenter> command;

        public ViewAllBillsBranch(IRunThe<IViewAllBillsPresenter> command)
        {
            this.command = command;
        }

        public void visit(ITreeBranch item_to_visit)
        {
            item_to_visit.add_child("View All Bills", ApplicationIcons.AddIncome, command);
        }
    }
}