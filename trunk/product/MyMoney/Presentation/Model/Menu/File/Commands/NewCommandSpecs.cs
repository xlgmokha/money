using developwithpassion.bdd.contexts;
using MoMoney.Modules.Core;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    [Concern(typeof (NewCommand))]
    public abstract class behaves_like_new_command : concerns_for<INewCommand, NewCommand>
    {
        context c = () =>
                        {
                            current_project = the_dependency<IProjectController>();
                            command = the_dependency<ILoadPresentationModulesCommand>();
                            save_changes_command = the_dependency<ISaveChangesCommand>();
                        };

        protected static IProjectController current_project;
        protected static ILoadPresentationModulesCommand command;
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
        it should_start_a_new_project = () => current_project.was_told_to(x => x.start_new_project());

        because b = () => sut.saved();
    }

    public class when_starting_a_new_project_after_declining_to_save_a_previous_one : behaves_like_new_command
    {
        it should_start_a_new_project = () => current_project.was_told_to(x => x.start_new_project());

        because b = () => sut.not_saved();
    }

    public class when_starting_a_new_project_and_cancelling_when_asked_to_save_the_changes_to_a_previous_project :
        behaves_like_new_command
    {
        it should_not_start_a_new_project =
            () => current_project.was_not_told_to(x => x.start_new_project());

        because b = () => sut.cancelled();
    }
}