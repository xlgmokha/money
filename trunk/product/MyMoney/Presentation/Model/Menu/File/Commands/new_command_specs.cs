using jpboodhoo.bdd.contexts;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    [Concern(typeof (new_command))]
    public abstract class behaves_like_new_command : concerns_for<INewCommand, new_command>
    {
        public override INewCommand create_sut()
        {
            return new new_command(current_project, command, save_changes_command);
        }

        context c = () =>
                        {
                            current_project = the_dependency<IProject>();
                            command = the_dependency<ILoadApplicationShellCommand>();
                            save_changes_command = the_dependency<ISaveChangesCommand>();
                        };

        protected static IProject current_project;
        protected static ILoadApplicationShellCommand command;
        protected static ISaveChangesCommand save_changes_command;
    }

    public class before_starting_a_new_project : behaves_like_new_command
    {
        it should_check_to_see_if_there_were_any_unsaved_changes_to_a_previous_project =
            () => save_changes_command.was_told_to(x => x.run(sut));

        because b = () => sut.run();
    }

    public class when_starting_a_new_project_after_saving_a_previous_one : behaves_like_new_command
    {
        it should_start_a_new_project = () => current_project.was_told_to(x => x.start_a_new_project());

        because b = () => sut.saved();
    }

    public class when_starting_a_new_project_after_declining_to_save_a_previous_one : behaves_like_new_command
    {
        it should_start_a_new_project = () => current_project.was_told_to(x => x.start_a_new_project());

        because b = () => sut.not_saved();
    }

    public class when_starting_a_new_project_and_cancelling_when_asked_to_save_the_changes_to_a_previous_project :
        behaves_like_new_command
    {
        it should_not_start_a_new_project =
            () => current_project.should_not_have_been_asked_to(x => x.start_a_new_project());

        because b = () => sut.cancelled();
    }
}