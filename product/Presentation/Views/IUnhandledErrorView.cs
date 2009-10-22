using System;
using momoney.presentation.presenters;

namespace momoney.presentation.views
{
    public interface IUnhandledErrorView : IView<IUnhandledErrorPresenter>
    {
        void display(Exception exception);
    }
}