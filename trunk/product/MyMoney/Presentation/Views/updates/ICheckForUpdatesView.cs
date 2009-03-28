using MoMoney.Domain.Core;
using MoMoney.Presentation.Model.updates;
using MoMoney.Presentation.Presenters.updates;
using MoMoney.Presentation.Views.core;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Views.updates
{
    public interface ICheckForUpdatesView : IView<ICheckForUpdatesPresenter>, ICallback<ApplicationVersion>
    {
        void display();
        void downloaded(Percent percentage_complete);
        void update_complete();
        void close();
    }
}