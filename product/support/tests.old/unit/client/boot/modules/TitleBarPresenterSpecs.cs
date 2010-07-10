using momoney.presentation.model.eventing;
using MoMoney.Presentation.Model.Projects;
using momoney.presentation.presenters;
using momoney.presentation.views;
using MoMoney.Presentation.Views;

namespace tests.unit.client.boot.modules
{
    public abstract class behaves_like_a_title_bar_presenter : runner<TitleBarPresenter>
    {
        context c = () =>
        {
            project = dependency<IProjectController>();
            view = dependency<ITitleBar>();
        };

        static protected ITitleBar view;
        static protected IProjectController project;
    }

    [Concern(typeof (TitleBarPresenter))]
    public class when_initializing_the_title_bar_for_the_first_time : behaves_like_a_title_bar_presenter
    {
        it should_display_the_name_of_the_file_that_is_opened = () => view.was_told_to(x => x.display("untitled.mo"));

        context c = () =>
        {
            shell = an<Shell>();
            project.is_told_to(x => x.name()).it_will_return("untitled.mo");
        };

        because b = () => sut.present(shell);

        static Shell shell;
    }

    [Concern(typeof (TitleBarPresenter))]
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