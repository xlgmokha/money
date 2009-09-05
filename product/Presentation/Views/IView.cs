using System;
using System.ComponentModel;
using MoMoney.Presentation.Core;

namespace MoMoney.Presentation.Views.Core
{
    public interface IView : IWindowEvents, ISynchronizeInvoke, IDisposable
    {
    }

    public interface IView<TPresenter> : IView where TPresenter : IPresenter
    {
        void attach_to(TPresenter presenter);
    }
}