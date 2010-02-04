using System;

namespace momoney.presentation.views
{
    public interface View //: IDisposable 
    {}

    public interface View<Presenter> : View where Presenter : MoMoney.Presentation.Core.Presenter
    {
        void attach_to(Presenter presenter);
    }
}