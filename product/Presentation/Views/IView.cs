using System;
using System.ComponentModel;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;

namespace momoney.presentation.views
{
    public interface IView : IWindowEvents, ISynchronizeInvoke, IDisposable
    {
    }

    public interface IView<Presenter> : IView where Presenter : IPresenter
    {
        void attach_to(Presenter presenter);
    }
}