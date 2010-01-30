using System;
using System.ComponentModel;

namespace momoney.presentation.views
{
    public interface View : ISynchronizeInvoke, IDisposable
    {
    }

    public interface View<Presenter> : View where Presenter : MoMoney.Presentation.Core.Presenter
    {
        void attach_to(Presenter presenter);
    }
}