using System.Windows.Forms;

namespace MyMoney.Presentation.Model.Menu
{
    internal class menu_item_separator : IMenuItem
    {
        public string name { get; set; }

        public void click()
        {}

        public ToolStripItem build()
        {
            return new ToolStripSeparator();
        }

        public MenuItem build_menu_item()
        {
            return new MenuItem("----------");
        }
    }
}