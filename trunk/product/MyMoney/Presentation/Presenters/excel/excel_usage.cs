using System.Collections.Generic;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Presenters.excel.formatting;

namespace MoMoney.Presentation.Presenters.excel
{
    public class excel_usage
    {
        public IEnumerable<ICellVisitor> run()
        {
            yield return new constrained_cell_visitor(
                new change_font_size(8),
                Cell.occurs_between_columns(3, 8)
                    .and(Cell.occurs_after_row(5))
                    .or(Cell.is_named("P3")));
        }
    }
}