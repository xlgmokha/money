using System;
using MyMoney.Presentation.Presenters.Shell;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.Shell
{
    public interface IUnhandledErrorView : IView<IUnhandledErrorPresenter>
    {
        void display(Exception exception);
    }
}