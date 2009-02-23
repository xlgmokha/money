namespace MyMoney.Presentation.Presenters.excel.formatting
{
    public class change_font_size : ICellVisitor
    {
        private readonly int font_size;

        public change_font_size(int font_size)
        {
            this.font_size = font_size;
        }

        public void visit(ICell item_to_visit)
        {
            item_to_visit.Interior.FontSize = font_size;
        }
    }
}