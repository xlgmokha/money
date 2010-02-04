using System;
using System.Windows.Forms;
using momoney.presentation.presenters;
using momoney.presentation.views;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Winforms.Views
{
    public class TitleBar : ITitleBar
    {
        IRegionManager shell;

        public TitleBar(IRegionManager shell)
        {
            this.shell = shell;
        }

        public void attach_to(TitleBarPresenter presenter)
        {
        }

        public void display(string title)
        {
            shell.region<Form>(x =>
            {
                if (x.Text.Contains("-")) x.Text = x.Text.Remove(x.Text.IndexOf("-") - 1);
                x.Text = x.Text + " - " + title;
            });
        }

        public void append_asterik()
        {
            shell.region<Form>(x =>
            {
                if (x.Text.Contains("*")) return;
                x.Text = x.Text + "*";
            });
        }

        public void remove_asterik()
        {
            shell.region<Form>(x =>
            {
                x.Text = x.Text.Replace("*", "");
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
            method.DynamicInvoke(args);
            return new object();
        }

        public bool InvokeRequired
        {
            get { return false; }
        }

        public void Dispose()
        {
        }
    }
}