using System;
using System.ComponentModel;
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

            activated = x => { };
            deactivated = x => { };
            closed = x => { };
            closing = x => { };
        }

        public ControlAction<EventArgs> activated { get; set; }
        public ControlAction<EventArgs> deactivated { get; set; }
        public ControlAction<EventArgs> closed { get; set; }
        public ControlAction<CancelEventArgs> closing { get; set; }

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

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            activated(e);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            deactivated(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            closing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            closed(e);
        }
    }
}