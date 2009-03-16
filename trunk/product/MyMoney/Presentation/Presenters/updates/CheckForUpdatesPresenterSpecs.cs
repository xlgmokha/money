using developwithpassion.bdd.contexts;
using MoMoney.Presentation.Model.updates;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.updates;
using MoMoney.Tasks.infrastructure;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Presenters.updates
{
    [Concern(typeof (CheckForUpdatesPresenter))]
    public abstract class behaves_like_check_for_updates_presenter :
        concerns_for<ICheckForUpdatesPresenter, CheckForUpdatesPresenter>
    {
        context c = () =>
                        {
                            view = the_dependency<ICheckForUpdatesView>();
                            tasks = the_dependency<IUpdateTasks>();
                            command = the_dependency<IRestartCommand>();
                        };

        static protected ICheckForUpdatesView view;
        static protected IUpdateTasks tasks;
        static protected IRestartCommand command;
    }

    public class when_attempting_to_check_for_updates : behaves_like_check_for_updates_presenter
    {
        it should_tell_the_view_to_attach_itself_to_the_presenter = () => view.was_told_to(x => x.attach_to(sut));

        it should_tell_the_view_to_display_the_information_on_the_current_version_of_the_application =
            () => view.was_told_to(x => x.display(version));

        context c = () =>
                        {
                            version = an<ApplicationVersion>();
                            when_the(tasks).is_told_to(x => x.current_application_version()).it_will_return(version);
                        };

        because b = () => sut.run();

        static ApplicationVersion version;
    }

    public class when_initiating_an_update_and_one_is_available : behaves_like_check_for_updates_presenter
    {
        it should_start_downloading_the_latest_version_of_the_application =
            () => tasks.was_told_to(x => x.grab_the_latest_version(sut));

        because b = () => sut.begin_update();
    }

    public class when_downloading_an_update : behaves_like_check_for_updates_presenter
    {
        it should_notify_you_of_the_progress_of_the_update = () => view.was_told_to(x => x.downloaded(50));

        because b = () => sut.complete(50);
    }

    public class when_an_update_is_completed : behaves_like_check_for_updates_presenter
    {
        it should_notify_the_view_that_the_update_is_complete = () => view.was_told_to(x => x.update_complete());

        because b = () => sut.complete(100);
    }

    public class when_an_update_is_cancelled : behaves_like_check_for_updates_presenter
    {
        it should_stop_downloading_the_latest_update = () => tasks.was_told_to(x => x.stop_updating());

        because b = () => sut.cancel_update();
    }

    public class when_an_update_is_complete_and_the_user_agrees_to_restart_the_application :
        behaves_like_check_for_updates_presenter
    {
        it should_restart_the_application = () => command.run();

        because b = () => sut.restart();
    }
}