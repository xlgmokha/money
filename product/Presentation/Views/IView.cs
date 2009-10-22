using System;
using System.ComponentModel;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;

namespace momoney.presentation.views
{
    public interface IView : IWindowEvents, ISynchronizeInvoke, IDisposable
    {
    }

    public interface IView<TPresenter> : IView where TPresenter : IPresenter
    {
        void attach_to(TPresenter presenter);
    }
}