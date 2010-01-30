using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using momoney.presentation.presenters;
using momoney.service.infrastructure.updating;

namespace momoney.presentation.views
{
    public interface ICheckForUpdatesView : Dialog<CheckForUpdatesPresenter>, Callback<ApplicationVersion>
    {
        void display();
        void downloaded(Percent percentage_complete);
        void update_complete();
        void close();
    }
}