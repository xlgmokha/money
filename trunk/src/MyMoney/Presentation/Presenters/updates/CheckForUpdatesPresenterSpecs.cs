using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Model.updates;
using MyMoney.Presentation.Views.updates;
using MyMoney.Tasks.infrastructure;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Presenters.updates
{
    [Concern(typeof (CheckForUpdatesPresenter))]
    public class behaves_like_check_for_updates_presenter : concerns_for<ICheckForUpdatesPresenter, CheckForUpdatesPresenter>
    {
        public override ICheckForUpdatesPresenter create_sut()
        {
            return new CheckForUpdatesPresenter(view, tasks);
        }

        context c = () =>
                        {
                            view = the_dependency<ICheckForUpdatesView>();
                            tasks = the_dependency<IUpdateTasks>();
                        };

        protected static ICheckForUpdatesView view;
        protected static IUpdateTasks tasks;
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

    public class when_an_update_is_completed : behaves_like_check_for_updates_presenter
    {
        it should_notify_the_view_that_the_update_is_complete = () => view.was_told_to(x => x.update_complete());

        because b = () => sut.complete();
    }
}