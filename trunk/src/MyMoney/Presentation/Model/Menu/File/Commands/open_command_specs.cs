using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Model.Projects;
using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Views.dialogs;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Model.Menu.File.Commands
{
    [Concern(typeof (open_command))]
    public abstract class behaves_like_command_to_open_a_project : concerns_for<IOpenCommand, open_command>
    {
        public override IOpenCommand create_sut()
        {
            return new open_command(view, project, command, save_changes_command);
        }

        context c = () =>
                        {
                            view = the_dependency<ISelectFileToOpenDialog>();
                            command = the_dependency<ILoadApplicationShellCommand>();
                            project = the_dependency<IProject>();
                            save_changes_command = the_dependency<ISaveChangesCommand>();
                        };

        protected static IProject project;
        protected static ISelectFileToOpenDialog view;
        protected static ILoadApplicationShellCommand command;
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
        it should_open_the_project_at_the_file_path_specified = () => project.was_told_to(x => x.open(file_path));

        it will_re_load_the_application_shell = () => command.was_told_to(x => x.run());

        context c = () =>
                        {
                            file_path = "blah_blah";
                            when_the(view).is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(file_path);
                        };

        because b = () => sut.saved();

        static file file_path;
    }

    public class when_opening_a_project_after_declining_to_save_the_previous_project :
        behaves_like_command_to_open_a_project
    {
        it should_open_the_project_at_the_file_path_specified = () => project.was_told_to(x => x.open(file_path));

        it will_re_load_the_application_shell = () => command.was_told_to(x => x.run());

        context c = () =>
                        {
                            file_path = "blah_blah";
                            when_the(view).is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(file_path);
                        };

        because b = () => sut.not_saved();

        static file file_path;
    }

    public class
        when_opening_a_new_project_and_then_deciding_that_you_want_to_continue_working_on_the_previously_opened_project :
            behaves_like_command_to_open_a_project
    {
        it should_not_open_the_project_at_the_file_path_specified =
            () => project.should_not_have_been_asked_to(x => x.open(file_path));

        it will_not_re_load_the_application_shell = () => command.should_not_have_been_asked_to(x => x.run());

        context c = () =>
                        {
                            file_path = "blah_blah";
                            when_the(view).is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(file_path);
                        };

        because b = () => sut.cancelled();

        static file file_path;
    }
}