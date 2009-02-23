using jpboodhoo.bdd.contexts;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Utility.Core;
using Rhino.Mocks;

namespace MyMoney.Infrastructure.Threading
{
    [Concern(typeof (background_thread))]
    public abstract class behaves_like_a_background_thread : concerns_for<IBackgroundThread, background_thread>
    {
        public override IBackgroundThread create_sut()
        {
            return new background_thread(command_to_execute, worker_thread);
        }

        context c = () =>
                        {
                            command_to_execute = the_dependency<IDisposableCommand>();
                            //worker_thread = the_dependency<worker_thread>();
                            worker_thread = dependency<worker_thread>();
                        };

        protected static IDisposableCommand command_to_execute;
        protected static worker_thread worker_thread;
    }

    public class when_executing_a_command_on_a_background_thread : behaves_like_a_background_thread
    {
        it should_execute_the_command_asynchronously = () => command_to_execute.was_told_to(c => c.run());

        it should_start_the_worker_thread_asynchronously = () => worker_thread.was_told_to(t => t.Begin());

        because b = () =>
                        {
                            sut.run();
                            worker_thread.Raise(t => t.DoWork += null, null, null);
                        };
    }

    public class when_disposing_a_background_thread : behaves_like_a_background_thread
    {
        it should_dispose_the_command_running_on_the_thread = () => worker_thread.was_told_to(w => w.Dispose());

        because b = () => sut.Dispose();
    }
}