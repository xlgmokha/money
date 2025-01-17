using momoney.presentation.model.menu.file;
using MoMoney.Presentation.Model.Projects;

namespace tests.unit.client.presentation.model
{
    [Concern(typeof (SaveCommand))]
    public abstract class behaves_like_the_save_command : TestsFor<ISaveCommand>
    {
        public override ISaveCommand create_sut()
        {
            return new SaveCommand(current_project, save_as_command);
        }

        context c = () =>
        {
            current_project = an<IProjectController>();
            save_as_command = an<ISaveAsCommand>();
        };

        static protected ISaveAsCommand save_as_command;
        static protected IProjectController current_project;
    }

    public class when_saving_the_current_project_that_has_not_been_saved_yet : behaves_like_the_save_command
    {
        it should_prompt_the_user_to_specifiy_the_path_to_save_to = () => save_as_command.was_told_to(x => x.run());

        context c = () => current_project
                              .is_told_to(x => x.has_been_saved_at_least_once())
                              .it_will_return(false);

        because b = () => sut.run();

        public override ISaveCommand create_sut()
        {
            return new SaveCommand(current_project, save_as_command);
        }
    }

    [Concern(typeof (SaveCommand))]
    public class when_saving_the_current_project_that_has_been_saved_before : behaves_like_the_save_command
    {
        it should_save_the_current_project_to_the_same_path = () => current_project.was_told_to(x => x.save_changes());

        context c = () => current_project
                              .is_told_to(x => x.has_been_saved_at_least_once())
                              .it_will_return(true);

        because b = () => sut.run();

        public override ISaveCommand create_sut()
        {
            return new SaveCommand(current_project, save_as_command);
        }
    }
}