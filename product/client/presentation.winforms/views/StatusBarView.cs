using System;
using System.Windows.Forms;
using momoney.presentation.presenters;
using momoney.presentation.resources;
using momoney.presentation.views;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Winforms.Views
{
    public class StatusBarView : IStatusBarView
    {
        IRegionManager shell;

        public void attach_to(StatusBarPresenter presenter)
        {
            shell = presenter.shell;
        }

        public void display(HybridIcon icon_to_display, string text_to_display)
        {
            shell.region<ToolStripStatusLabel>(x =>
            {
                x.Text = text_to_display;
                x.Image = icon_to_display;
            });
        }

        public void reset_progress_bar()
        {
            shell.region<ToolStripProgressBar>(x =>
            {
                x.ProgressBar.Value = 0;
            });
        }

        public void notify()
        {
            shell.region<ToolStripProgressBar>(x =>
            {
                x.Increment(10);
            });
        }

        public IAsyncResult BeginInvoke(Delegate method, object[] args)
        {
            throw new NotImplementedException();
        }

        public object EndInvoke(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public object Invoke(Delegate method, object[] args)
        {
            throw new NotImplementedException();
        }

        public bool InvokeRequired
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose() {}
    }
}