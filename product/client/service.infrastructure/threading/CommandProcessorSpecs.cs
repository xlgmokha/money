using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Threading;

namespace momoney.service.infrastructure.threading
{
    [Concern(typeof (SynchronousCommandProcessor))]
    public abstract class behaves_like_a_command_processor : concerns_for<CommandProcessor, SynchronousCommandProcessor> {}

    [Concern(typeof (SynchronousCommandProcessor))]
    public class when_running_all_the_queued_commands_waiting_for_execution : behaves_like_a_command_processor
    {
        it should_run_the_first_command_in_the_queue = () => first_command.was_told_to(f => f.run());

        it should_run_the_second_command_in_the_queue = () => second_command.was_told_to(f => f.run());

        context c = () =>
        {
            first_command = an<Command>();
            second_command = an<Command>();
        };

        because b = () =>
        {
            sut.add(first_command);
            sut.add(second_command);
            sut.run();
        };

        static Command first_command;
        static Command second_command;
    }

    [Concern(typeof (SynchronousCommandProcessor))]
    public class when_attempting_to_rerun_the_command_processor : behaves_like_a_command_processor
    {
        it should_not_re_run_the_commands_that_have_already_executed =
            () => first_command.was_told_to(f => f.run()).only_once();

        context c = () =>
        {
            first_command = an<Command>();
        };

        because b = () =>
        {
            sut.add(first_command);
            sut.run();
            sut.run();
        };

        static Command first_command;
    }
}