using System;
using momoney.presentation.presenters;

namespace momoney.presentation.views
{
    public interface IUnhandledErrorView : IView<UnhandledErrorPresenter>
    {
        void display(Exception exception);
    }
}