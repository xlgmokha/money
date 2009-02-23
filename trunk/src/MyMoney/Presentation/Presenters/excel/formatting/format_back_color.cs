using System.Drawing;

namespace MyMoney.Presentation.Presenters.excel.formatting
{
    public class format_back_color : ICellVisitor
    {
        private readonly Color color;

        public format_back_color(Color color)
        {
            this.color = color;
        }

        public void visit(ICell cell)
        {
            cell.Interior.Color = color;
        }
    }
}