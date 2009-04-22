using System;
using MoMoney.Presentation.Presenters.Shell;
using MoMoney.Presentation.Views.Core;

namespace MoMoney.Presentation.Views.Shell
{
    public interface IUnhandledErrorView : IView<IUnhandledErrorPresenter>
    {
        void display(Exception exception);
    }
}