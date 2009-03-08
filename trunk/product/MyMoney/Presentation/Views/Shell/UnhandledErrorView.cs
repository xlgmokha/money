using System;
using MoMoney.Presentation.Presenters.Shell;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Shell
{
    public partial class UnhandledErrorView : ApplicationWindow, IUnhandledErrorView
    {
        public UnhandledErrorView()
        {
            InitializeComponent();
            titled("Aw snap... an error occurred");
        }

        public void attach_to(IUnhandledErrorPresenter presenter)
        {
        }

        public void display(Exception exception)
        {
            if (InvokeRequired)
            {
                on_ui_thread(() => ux_message.Text = exception.ToString());
            }
            else
            {
                ux_message.Text = exception.ToString();
            }
        }
    }
}