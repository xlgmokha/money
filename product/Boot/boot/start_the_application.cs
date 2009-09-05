using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Utility.Core;
using MoMoney.Modules.Core;

namespace MoMoney.boot
{
    internal class start_the_application : ICommand
    {
        readonly IBackgroundThread thread;
        readonly ILoadPresentationModulesCommand command;
        readonly ICommandProcessor processor;

        public start_the_application(IBackgroundThread thread)
            : this(thread, Lazy.load<ILoadPresentationModulesCommand>(), Lazy.load<ICommandProcessor>())
        {
        }

        public start_the_application(IBackgroundThread thread, ILoadPresentationModulesCommand command,
                                     ICommandProcessor processor)
        {
            this.thread = thread;
            this.command = command;
            this.processor = processor;
        }

        public void run()
        {
            command.run();
            processor.add(() => thread.Dispose());
            processor.run();
        }
    }
}