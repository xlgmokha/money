using System;
using System.ComponentModel;

namespace momoney.presentation.views
{
    public interface IView : ISynchronizeInvoke, IDisposable
    {
    }

    public interface IView<Presenter> : IView where Presenter : MoMoney.Presentation.Core.Presenter
    {
        void attach_to(Presenter presenter);
    }
}