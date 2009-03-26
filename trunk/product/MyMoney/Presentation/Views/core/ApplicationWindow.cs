using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using MoMoney.Infrastructure.Extensions;
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
        protected readonly SynchronizationContext context;
        AsyncOperation operation;

        public ApplicationWindow()
        {
            InitializeComponent();
            Icon = ApplicationIcons.Application;
            this.log().debug("created {0}", GetType());
            context = SynchronizationContext.Current;
            operation = AsyncOperationManager.CreateOperation(null);
            Debug.Assert(null != context, "The Synchronization Context is not there");
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
            Focus();
            BringToFront();
            return this;
        }

        public IApplicationWindow titled(string title)
        {
            base.Text = "MoMoney - " + title;
            return this;
        }

        protected void on_ui_thread(Action action)
        {
            //context.Post(x => action(), new object());
            //context.Send(x => action(), new object());
            action();
            //operation.Post(x => action(), new object());
            //if (InvokeRequired)
            //{
            //    BeginInvoke(action);
            //}
            //else
            //{
            //    action();
            //}
        }
    }
}