using System.Collections.Generic;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Model.Excel
{
    public class CompositeCellVisitor : ICellVisitor
    {
        readonly IList<ICellVisitor> all_visitors;

        public CompositeCellVisitor()
        {
            all_visitors = new List<ICellVisitor>();
        }

        public void add(ICellVisitor visitor)
        {
            all_visitors.Add(visitor);
        }

        public void add_all(IEnumerable<ICellVisitor> visitors)
        {
            visitors.each(add);
        }

        public void visit(ICell cell)
        {
            all_visitors.each(x => x.visit(cell));
        }
    }
}