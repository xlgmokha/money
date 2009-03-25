using MoMoney.Presentation.Resources;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Navigation.branches
{
    public class AddNewIncomeBranch : IBranchVisitor
    {
        public void visit(ITreeBranch item_to_visit)
        {
            item_to_visit.add_child("Add New Income", ApplicationIcons.AddIncome, new EmptyCommand());
        }
    }
}