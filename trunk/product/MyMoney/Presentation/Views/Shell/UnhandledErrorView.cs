using System;
using System.Windows.Forms;
using MyMoney.Presentation.Presenters.Shell;

namespace MyMoney.Presentation.Views.Shell
{
    public class UnhandledErrorView : IUnhandledErrorView
    {
        public void attach_to(IUnhandledErrorPresenter presenter)
        {
        }

        public void display(Exception exception)
        {
            MessageBox.Show(exception.ToString());
        }

        public IAsyncResult BeginInvoke(Delegate method, object[] args)
        {
            return null;
        }

        public object EndInvoke(IAsyncResult result)
        {
            return new object();
        }

        public object Invoke(Delegate method, object[] args)
        {
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