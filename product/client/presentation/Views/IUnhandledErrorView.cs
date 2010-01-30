using System;
using momoney.presentation.presenters;

namespace momoney.presentation.views
{
    public interface IUnhandledErrorView : Dialog<UnhandledErrorPresenter>
    {
        void display(Exception exception);
    }
}