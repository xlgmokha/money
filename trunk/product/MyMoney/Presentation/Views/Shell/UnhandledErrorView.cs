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
            ux_message.Text = exception.ToString();
        }
    }
}