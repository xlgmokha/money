using System.Windows.Forms;
using momoney.presentation.views;
using MoMoney.Presentation.Winforms.Helpers;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class ApplicationWindow : Form, IApplicationWindow
    {
        public ApplicationWindow()
        {
            InitializeComponent();
            Icon = ApplicationIcons.Application;
        }

        public IApplicationWindow create_tool_tip_for(string title, string caption, Control control)
        {
            var tip = new ToolTip {IsBalloon = true, ToolTipTitle = title};
            tip.SetToolTip(control, caption);
            control.Controls.Add(new ControlAdapter(tip));
            return this;
        }

        public IApplicationWindow try_to_reduce_flickering()
        {
            base.DoubleBuffered = true;
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            return this;
        }

        public IApplicationWindow top_most()
        {
            TopMost = true;
            Focus();
            BringToFront();
            return this;
        }

        public IApplicationWindow titled(string title)
        {
            base.Text = "MoMoney (BETA) - " + title;
            return this;
        }
    }
}