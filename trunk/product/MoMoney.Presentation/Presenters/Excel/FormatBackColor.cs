using System.Drawing;
using MoMoney.Presentation.Presenters.excel;

namespace MoMoney.Presentation.Presenters.Excel
{
    public class FormatBackColor : ICellVisitor
    {
        private readonly Color color;

        public FormatBackColor(Color color)
        {
            this.color = color;
        }

        public void visit(ICell cell)
        {
            cell.Interior.Color = color;
        }
    }
}