using System;

namespace presentation.windows
{
    public interface DialogPresenter : Presenter
    {
        Action close { set; }
    }
}