using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.DTO;
using momoney.presentation.presenters;

namespace momoney.presentation.views
{
    public interface ICheckForUpdatesView : IView<ICheckForUpdatesPresenter>, Callback<ApplicationVersion>
    {
        void display();
        void downloaded(Percent percentage_complete);
        void update_complete();
        void close();
    }
}