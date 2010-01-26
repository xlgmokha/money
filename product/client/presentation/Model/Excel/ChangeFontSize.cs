namespace MoMoney.Presentation.Model.Excel
{
    public class ChangeFontSize : ICellVisitor
    {
        private readonly int font_size;

        public ChangeFontSize(int font_size)
        {
            this.font_size = font_size;
        }

        public void visit(ICell item_to_visit)
        {
            item_to_visit.Interior.FontSize = font_size;
        }
    }
}