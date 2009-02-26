using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Model.updates;
using MyMoney.Presentation.Views.updates;
using MyMoney.Tasks.infrastructure;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Presenters.updates
{
    public class behaves_like_check_for_updates_presenter :
        concerns_for<ICheckForUpdatesPresenter, CheckForUpdatesPresenter>
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
}