using System;
using System.ComponentModel;
using MyMoney.Presentation.Core;

namespace MyMoney.Presentation.Views.core
{
    public interface IView : ISynchronizeInvoke, IDisposable
    {
    }

    public interface IView<Presenter> : IView where Presenter : IPresenter
    {
        void attach_to(Presenter presenter);
    }
}