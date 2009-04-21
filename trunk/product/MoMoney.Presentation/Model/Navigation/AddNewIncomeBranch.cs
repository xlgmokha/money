using Gorilla.Commons.Utility.Core;
using MoMoney.Presentation.Resources;

namespace MoMoney.Presentation.Model.Navigation
{
    public class AddNewIncomeBranch : IBranchVisitor
    {
        public void visit(ITreeBranch item_to_visit)
        {
            item_to_visit.add_child("Add New Income", ApplicationIcons.AddIncome, new EmptyCommand());
        }
    }
}