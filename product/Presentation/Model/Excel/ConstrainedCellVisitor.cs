using gorilla.commons.utility;

namespace MoMoney.Presentation.Model.Excel
{
    public class ConstrainedCellVisitor : ICellVisitor
    {
        readonly ICellVisitor cell_visitor;
        readonly Specification<ICell> constraint;

        public ConstrainedCellVisitor(ICellVisitor cell_visitor, Specification<ICell> constraint)
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