using System;
using MoMoney.Presentation.Presenters;

namespace MoMoney.Presentation.Views
{
    public interface IUnhandledErrorView : IView<IUnhandledErrorPresenter>
    {
        void display(Exception exception);
    }
}