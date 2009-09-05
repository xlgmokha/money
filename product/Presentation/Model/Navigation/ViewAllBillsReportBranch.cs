using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Presenters.reporting;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Model.Navigation
{
    public class ViewAllBillsReportBranch : IBranchVisitor
    {
        private readonly IRunThe<IViewAllBillsReportPresenter> command;

        public ViewAllBillsReportBranch(IRunThe<IViewAllBillsReportPresenter> command)
        {
            this.command = command;
        }

        public void visit(ITreeBranch item_to_visit)
        {
            item_to_visit.add_child("View All Bills Report", ApplicationIcons.AddIncome, command);
        }
    }
}