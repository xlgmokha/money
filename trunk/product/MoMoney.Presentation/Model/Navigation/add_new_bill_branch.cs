using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Resources;

namespace MoMoney.Presentation.Model.Navigation.branches
{
    public class add_new_bill_branch : IBranchVisitor
    {
        readonly IRunPresenterCommand command;

        public add_new_bill_branch(IRunPresenterCommand command)
        {
            this.command = command;
        }

        public void visit(ITreeBranch item_to_visit)
        {
            item_to_visit.add_child("Add Bills", ApplicationIcons.AddIncome, () => command.run<IAddCompanyPresenter>());
        }
    }
}