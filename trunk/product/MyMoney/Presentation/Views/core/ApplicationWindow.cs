using System;
using System.Windows.Forms;
using MoMoney.Presentation.Resources;

namespace MoMoney.Presentation.Views.core
{
    public interface IApplicationWindow : IView
    {
        IApplicationWindow titled(string title);
        IApplicationWindow create_tool_tip_for(string title, string caption, Control control);
        IApplicationWindow try_to_reduce_flickering();
        IApplicationWindow top_most();
    }

    public partial class ApplicationWindow : Form, IApplicationWindow
    {
        public ApplicationWindow()
        {
            InitializeComponent();
            Icon = ApplicationIcons.Application;
        }

        public IApplicationWindow create_tool_tip_for(string title, string caption, Control control)
        {
            new ToolTip {IsBalloon = true, ToolTipTitle = title}.SetToolTip(control, caption);
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
            return this;
        }

        public IApplicationWindow titled(string title)
        {
            base.Text = "MoMoney - " + title;
            return this;
        }

        protected void on_ui_thread(Action action)
        {
            if (InvokeRequired)
            {
                BeginInvoke(action);
            }
            else
            {
                action();
            }
        }
    }
}