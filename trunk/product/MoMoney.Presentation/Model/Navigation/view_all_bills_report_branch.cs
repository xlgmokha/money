using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Presenters.reporting;
using MoMoney.Presentation.Resources;

namespace MoMoney.Presentation.Model.Navigation.branches
{
    public class view_all_bills_report_branch : IBranchVisitor
    {
        private readonly IRunThe<IViewAllBillsReportPresenter> command;

        public view_all_bills_report_branch(IRunThe<IViewAllBillsReportPresenter> command)
        {
            this.command = command;
        }

        public void visit(ITreeBranch item_to_visit)
        {
            item_to_visit.add_child("View All Bills Report", ApplicationIcons.AddIncome, command);
        }
    }
}