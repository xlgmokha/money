using System;
using System.ComponentModel;
using System.Windows.Forms;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.helpers;

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
            //this.log().debug("created {0}", GetType());

            on_activated = x => { };
            on_deactivate = x => { };
            on_closed = x => { };
            on_closing = x => { };
        }

        public ControlAction<EventArgs> on_activated { get; set; }
        public ControlAction<EventArgs> on_deactivate { get; set; }
        public ControlAction<EventArgs> on_closed { get; set; }
        public ControlAction<CancelEventArgs> on_closing { get; set; }

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
            base.Text = "MoMoney - " + title;
            return this;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            on_activated(e);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            on_deactivate(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            on_closing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            on_closed(e);
        }
    }
}