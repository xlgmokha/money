using Gorilla.Commons.Utility.Core;

namespace MoMoney.Presentation.Presenters.excel
{
    public class ConstrainedCellVisitor : ICellVisitor
    {
        private readonly ICellVisitor cell_visitor;
        private readonly ISpecification<ICell> constraint;

        public ConstrainedCellVisitor(ICellVisitor cell_visitor, ISpecification<ICell> constraint)
        {
            this.cell_visitor = cell_visitor;
            this.constraint = constraint;
        }

        public void visit(ICell cell)
        {
            if (constraint.is_satisfied_by(cell)) cell_visitor.visit(cell);
        }
    }
}