using Gorilla.Commons.Infrastructure.FileSystem;
using momoney.presentation.model.menu.file;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Projects;
using momoney.presentation.views;

namespace tests.unit.client.presentation.model
{
    [Concern(typeof (OpenCommand))]
    public abstract class behaves_like_command_to_open_a_project : runner<OpenCommand>
    {
        context c = () =>
        {
            view = dependency<ISelectFileToOpenDialog>();
            project = dependency<IProjectController>();
            save_changes_command = dependency<ISaveChangesCommand>();
        };

        static protected IProjectController project;
        static protected ISelectFileToOpenDialog view;
        static protected ISaveChangesCommand save_changes_command;
    }

    public class before_opening_a_new_project : behaves_like_command_to_open_a_project
    {
        it should_check_to_see_if_you_want_to_save_the_previously_opened_project =
            () => save_changes_command.was_told_to(x => x.run_against(sut));

        because b = () => sut.run();
    }

    public class when_attempting_to_open_an_existing_project_after_saving_the_previous_project :
        behaves_like_command_to_open_a_project
    {
        it should_open_the_project_at_the_file_path_specified =
            () => project.was_told_to(x => x.open_project_from(file_path));

        context c = () =>
        {
            file_path = "blah_blah";
            view.is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(file_path);
        };

        because b = () => sut.saved();

        static ApplicationFile file_path;
    }

    public class when_opening_a_project_after_declining_to_save_the_previous_project :
        behaves_like_command_to_open_a_project
    {
        it should_open_the_project_at_the_file_path_specified =
            () => project.was_told_to(x => x.open_project_from(file_path));

        context c = () =>
        {
            file_path = "blah_blah";
            view.is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(file_path);
        };

        because b = () => sut.not_saved();

        static ApplicationFile file_path;
    }

    public class
        when_opening_a_new_project_and_then_deciding_that_you_want_to_continue_working_on_the_previously_opened_project :
            behaves_like_command_to_open_a_project
    {
        it should_not_open_the_project_at_the_file_path_specified =
            () => project.was_not_told_to(x => x.open_project_from(file_path));

        context c = () =>
        {
            file_path = "blah_blah";
            view.is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(file_path);
        };

        because b = () => sut.cancelled();

        static ApplicationFile file_path;
    }
}