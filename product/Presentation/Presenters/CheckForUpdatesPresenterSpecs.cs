using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.Presentation.Presenters;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using momoney.service.infrastructure.updating;

namespace momoney.presentation.presenters
{
    [Concern(typeof (CheckForUpdatesPresenter))]
    public abstract class behaves_like_check_for_updates_presenter : concerns_for< CheckForUpdatesPresenter>
    {
        context c = () =>
        {
            view = the_dependency<ICheckForUpdatesView>();
            pump = the_dependency<ICommandPump>();
        };

        static protected ICheckForUpdatesView view;
        static protected ICommandPump pump;
    }

    public class when_attempting_to_check_for_updates : behaves_like_check_for_updates_presenter
    {
        it should_tell_the_view_to_display_the_information_on_the_current_version_of_the_application =
            () => view.was_told_to(x => x.display());

        it should_go_and_find_out_what_the_latest_version_is =
            () => pump.was_told_to(x => x.run<ApplicationVersion, IWhatIsTheAvailableVersion>(view));

        context c = () =>
                    {
                        shell = an<IShell>();
                    };
        because b = () => sut.present(shell);
        static IShell shell;
    }

    public class when_initiating_an_update_and_one_is_available : behaves_like_check_for_updates_presenter
    {
        it should_start_downloading_the_latest_version_of_the_application =
            () => pump.was_told_to(x => x.run<IDownloadTheLatestVersion, Callback<Percent>>(sut));

        because b = () => sut.begin_update();
    }

    public class when_downloading_an_update : behaves_like_check_for_updates_presenter
    {
        it should_notify_you_of_the_progress_of_the_update = () => view.was_told_to(x => x.downloaded(50));

        because b = () => sut.run(50);
    }

    public class when_an_update_is_completed : behaves_like_check_for_updates_presenter
    {
        it should_notify_the_view_that_the_update_is_complete = () => view.was_told_to(x => x.update_complete());

        because b = () => sut.run(100);
    }

    public class when_an_update_is_cancelled : behaves_like_check_for_updates_presenter
    {
        it should_stop_downloading_the_latest_update = () => pump.was_told_to(x => x.run<ICancelUpdate>());

        because b = () => sut.cancel_update();
    }

    public class when_an_update_is_complete_and_the_user_agrees_to_restart_the_application :
        behaves_like_check_for_updates_presenter
    {
        it should_restart_the_application = () => pump.was_told_to(x => x.run<IRestartCommand>());

        because b = () => sut.restart();
    }
}