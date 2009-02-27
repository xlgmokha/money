using System.Windows.Forms;
using MyMoney.Presentation.Resources;

namespace MyMoney.Presentation.Views.core
{
    public partial class ApplicationWindow : Form
    {
        public ApplicationWindow(string title)
        {
            InitializeComponent();
            Icon = ApplicationIcons.Application;
            base.Text = "MoMoney - " + title;
        }

        protected ApplicationWindow create_tool_tip_for(string title, string caption, Control control)
        {
            new ToolTip {IsBalloon = true, ToolTipTitle = title}.SetToolTip(control, caption);
            return this;
        }
    }
}