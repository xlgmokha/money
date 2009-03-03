using MyMoney.Presentation.Model.updates;
using MyMoney.Presentation.Presenters.updates;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.updates
{
    public interface ICheckForUpdatesView : IView<ICheckForUpdatesPresenter>
    {
        void display(ApplicationVersion information);
        void update_complete();
        void close();
    }
}