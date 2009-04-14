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
            //this.log().debug("created {0}", GetType());
        }

        public IApplicationWindow create_tool_tip_for(string title, string caption, Control control)
        {
            var tip = new ToolTip {IsBalloon = true, ToolTipTitle = title};
            tip.SetToolTip(control, caption);
            control.Controls.Add(adapt(tip));
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

        Control adapt(IDisposable item)
        {
            return new ControlAdapter(item);
        }

        class ControlAdapter : Control
        {
            readonly IDisposable item;

            public ControlAdapter(IDisposable item)
            {
                this.item = item;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing) item.Dispose();
                base.Dispose(disposing);
            }
        }
    }
}