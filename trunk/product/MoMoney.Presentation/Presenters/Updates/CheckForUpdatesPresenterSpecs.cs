using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Model.updates;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.updates;
using MoMoney.Service.Infrastructure.Updating;
using MoMoney.Tasks.infrastructure.updating;

namespace MoMoney.Presentation.Presenters.updates
{
    [Concern(typeof (CheckForUpdatesPresenter))]
    public abstract class behaves_like_check_for_updates_presenter :
        concerns_for<ICheckForUpdatesPresenter, CheckForUpdatesPresenter>
    {
        context c = () =>
                        {
                            view = the_dependency<ICheckForUpdatesView>();
                            command = the_dependency<IRestartCommand>();
                            download_the_latest = the_dependency<IDownloadTheLatestVersion>();
                            pump = the_dependency<ICommandPump>();
                            cancel_update = the_dependency<ICancelUpdate>();
                        };

        protected static ICheckForUpdatesView view;
        protected static IRestartCommand command;
        protected static IDownloadTheLatestVersion download_the_latest;
        protected static ICancelUpdate cancel_update;
       protected static ICommandPump pump;
    }

    public class when_attempting_to_check_for_updates : behaves_like_check_for_updates_presenter
    {
        it should_tell_the_view_to_attach_itself_to_the_presenter = () => view.was_told_to(x => x.attach_to(sut));

        it should_tell_the_view_to_display_the_information_on_the_current_version_of_the_application =
            () => view.was_told_to(x => x.display());

        it should_go_and_find_out_what_the_latest_version_is = () => pump.was_told_to(x => x.run<ApplicationVersion, IWhatIsTheAvailableVersion>(view));

        because b = () => sut.run();
    }

    public class when_initiating_an_update_and_one_is_available : behaves_like_check_for_updates_presenter
    {
        it should_start_downloading_the_latest_version_of_the_application =
            () => download_the_latest.was_told_to(x => x.run(sut));

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
        it should_stop_downloading_the_latest_update = () => cancel_update.was_told_to(x => x.run());

        because b = () => sut.cancel_update();
    }

    public class when_an_update_is_complete_and_the_user_agrees_to_restart_the_application :
        behaves_like_check_for_updates_presenter
    {
        it should_restart_the_application = () => command.run();

        because b = () => sut.restart();
    }
}