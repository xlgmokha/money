using System;
using System.ComponentModel;
using MoMoney.Presentation.Core;

namespace MoMoney.Presentation.Views.core
{
    public interface IView : ISynchronizeInvoke, IDisposable
    {
    }

    public interface IView<Presenter> : IView where Presenter : IPresenter
    {
        void attach_to(Presenter presenter);
    }
}