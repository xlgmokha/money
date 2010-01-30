using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Views;

namespace momoney.modules
{
    [Concern(typeof (TitleBarPresenter))]
    public abstract class behaves_like_a_title_bar_presenter : concerns_for<TitleBarPresenter>
    {
        context c = () =>
        {
            project = the_dependency<IProjectController>();
            view = the_dependency<ITitleBar>();
        };

        static protected ITitleBar view;
        static protected IProjectController project;
    }

    public class when_initializing_the_title_bar_for_the_first_time : behaves_like_a_title_bar_presenter
    {
        it should_display_the_name_of_the_file_that_is_opened = () => view.was_told_to(x => x.display("untitled.mo"));

        context c = () => when_the(project).is_told_to(x => x.name()).it_will_return("untitled.mo");

        because b = () => sut.run();
    }

    public class when_there_are_unsaved_changes_in_the_project : behaves_like_a_title_bar_presenter
    {
        it should_display_an_asterik_in_the_title = () => view.was_told_to(x => x.append_asterik());

        context c = () =>
        {
            dto = new UnsavedChangesEvent();
        };

        because b = () => sut.notify(dto);

        static UnsavedChangesEvent dto;
    }
}