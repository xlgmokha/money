using developwithpassion.bdd.contexts;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Presenters.Shell
{
    [Concern(typeof (TitleBarPresenter))]
    public abstract class behaves_like_a_title_bar_presenter : concerns_for<ITitleBarPresenter, TitleBarPresenter>
    {
        context c = () =>
                        {
                            project = the_dependency<IProject>();
                            view = the_dependency<ITitleBar>();
                            broker = the_dependency<IEventAggregator>();
                        };

        protected static ITitleBar view;
        protected static IEventAggregator broker;
        protected static IProject project;
    }

    public class when_initializing_the_title_bar_for_the_first_time : behaves_like_a_title_bar_presenter
    {
        it should_display_the_name_of_the_file_that_is_opened = () => view.was_told_to(x => x.display("untitled.mo"));

        it should_ask_to_be_notified_of_any_unsaved_changes =
            () => broker.was_told_to(x => x.subscribe_to<UnsavedChangesEvent>(sut));

        it should_ask_to_be_notified_when_the_project_is_saved =
            () => broker.was_told_to(x => x.subscribe_to<SavedChangesEvent>(sut));

        it should_ask_to_be_notified_when_a_new_project_is_opened =
            () => broker.was_told_to(x => x.subscribe_to<NewProjectOpened>(sut));

        context c = () => when_the(project).is_told_to(x => x.name()).it_will_return("untitled.mo");

        because b = () => sut.run();
    }

    public class when_there_are_unsaved_changes_in_the_project : behaves_like_a_title_bar_presenter
    {
        it should_display_an_asterik_in_the_title = () => view.was_told_to(x => x.append_asterik());

        context c = () => { dto = new UnsavedChangesEvent(); };

        because b = () => sut.notify(dto);

        static UnsavedChangesEvent dto;
    }
}