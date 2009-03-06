using MoMoney.Presentation.Model.updates;
using MoMoney.Presentation.Presenters.updates;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.updates
{
    public interface ICheckForUpdatesView : IView<ICheckForUpdatesPresenter>
    {
        void display(ApplicationVersion information);
        void update_complete();
        void close();
    }
}