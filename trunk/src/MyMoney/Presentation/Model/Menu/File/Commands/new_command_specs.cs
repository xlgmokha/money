using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Model.Projects;
using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;

namespace MyMoney.Presentation.Model.Menu.File.Commands
{
    [Concern(typeof (new_command))]
    public class when_starting_a_new_project : concerns_for<INewCommand, new_command>
    {
        it should_start_a_new_project = () => current_project.was_told_to(x => x.start_a_new_project());

        context c = () =>
                        {
                            current_project = an<IProject>();
                            command = an<ILoadApplicationShellCommand>();
                        };

        because b = () => sut.run();

        public override INewCommand create_sut()
        {
            return new new_command(current_project, command);
        }

        static IProject current_project;
        static ILoadApplicationShellCommand command;
    }
}