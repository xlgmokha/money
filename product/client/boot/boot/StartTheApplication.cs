using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy;
using gorilla.commons.utility;
using MoMoney.Modules.Core;
using momoney.service.infrastructure.threading;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.boot
{
    class StartTheApplication : Command
    {
        readonly IBackgroundThread thread;
        readonly ILoadPresentationModulesCommand command;
        readonly CommandProcessor processor;

        public StartTheApplication(IBackgroundThread thread)
            : this(thread, Lazy.load<ILoadPresentationModulesCommand>(), Lazy.load<CommandProcessor>()) {}

        public StartTheApplication(IBackgroundThread thread, ILoadPresentationModulesCommand command,
                                     CommandProcessor processor)
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