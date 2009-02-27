using System.Windows.Forms;
using MyMoney.Presentation.Resources;

namespace MyMoney.Presentation.Views.core
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm(string title)
        {
            InitializeComponent();
            Icon = ApplicationIcons.Application;
            base.Text = "MoMoney - " + title;
        }

        protected void create_tool_tip_for(string title, string caption, Control control)
        {
            new ToolTip {IsBalloon = true, ToolTipTitle = title}.SetToolTip(control, caption);
        }
    }
}