using MoMoney.Infrastructure.interceptors;
using MoMoney.Infrastructure.Threading;
using MoMoney.Modules.Core;
using MoMoney.Utility.Core;

namespace MoMoney.boot
{
    internal class start_the_application : ICommand
    {
        readonly ILoadPresentationModulesCommand command;
        readonly ICommandProcessor processor;

        public start_the_application()
            : this(Lazy.load<ILoadPresentationModulesCommand>(), Lazy.load<ICommandProcessor>())
        {
        }

        public start_the_application(ILoadPresentationModulesCommand command, ICommandProcessor processor)
        {
            this.command = command;
            this.processor = processor;
        }

        public void run()
        {
            processor.run();
            command.run();
        }
    }
}