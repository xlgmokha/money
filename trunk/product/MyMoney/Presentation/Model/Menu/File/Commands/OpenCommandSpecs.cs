using developwithpassion.bdd.contexts;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Views.dialogs;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    [Concern(typeof (OpenCommand))]
    public abstract class behaves_like_command_to_open_a_project : concerns_for<IOpenCommand, OpenCommand>
    {
        context c = () =>
                        {
                            view = the_dependency<ISelectFileToOpenDialog>();
                            project = the_dependency<IProject>();
                            save_changes_command = the_dependency<ISaveChangesCommand>();
                        };

        protected static IProject project;
        protected static ISelectFileToOpenDialog view;
        protected static ISaveChangesCommand save_changes_command;
    }

    public class before_opening_a_new_project :
        behaves_like_command_to_open_a_project
    {
        it should_check_to_see_if_you_want_to_save_the_previously_opened_project =
            () => save_changes_command.was_told_to(x => x.run(sut));

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
                            when_the(view).is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(file_path);
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
                            when_the(view).is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(file_path);
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
                            when_the(view).is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(file_path);
                        };

        because b = () => sut.cancelled();

        static ApplicationFile file_path;
    }
}