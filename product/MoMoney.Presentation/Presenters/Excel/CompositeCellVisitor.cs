using System.Collections.Generic;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.excel
{
    public class CompositeCellVisitor : ICellVisitor
    {
        private readonly IList<ICellVisitor> all_visitors;

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