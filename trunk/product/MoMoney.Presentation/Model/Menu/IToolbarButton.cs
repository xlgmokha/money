using System.Windows.Forms;

namespace MoMoney.Presentation.Model.Menu
{
    public interface IToolbarButton
    {
        void add_to(ToolStrip collection);
        void refresh();
    }
}