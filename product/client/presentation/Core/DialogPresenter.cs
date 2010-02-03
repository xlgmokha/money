using System;

namespace MoMoney.Presentation.Core
{
    public interface DialogPresenter : Presenter
    {
        Action close { set; }
    }
}