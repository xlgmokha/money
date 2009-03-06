using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Presenters.excel
{
    public class constrained_cell_visitor : ICellVisitor
    {
        private readonly ICellVisitor cell_visitor;
        private readonly ISpecification<ICell> constraint;

        public constrained_cell_visitor(ICellVisitor cell_visitor, ISpecification<ICell> constraint)
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