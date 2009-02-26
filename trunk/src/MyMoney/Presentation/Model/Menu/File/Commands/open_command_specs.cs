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
            return new open_command(view, project, command);
        }

        context c = () =>
                        {
                            view = the_dependency<ISelectFileToOpenDialog>();
                            command = the_dependency<ILoadApplicationShellCommand>();
                            project = the_dependency<IProject>();
                        };

        protected static IProject project;
        protected static ISelectFileToOpenDialog view;
        protected static ILoadApplicationShellCommand command;
    }

    public class when_attempting_to_open_an_existing_project : behaves_like_command_to_open_a_project
    {
        context c = () =>
                        {
                            file_path = "blah_blah";
                            when_the(view).is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(file_path);
                        };

        because b = () => sut.run();

        it should_open_the_project_at_the_file_path_specified = () => project.was_told_to(x => x.open(file_path));

        it will_re_load_the_application_shell = () => command.was_told_to(x => x.run());

        static file file_path;
    }
}