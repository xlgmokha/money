using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy;
using gorilla.commons.utility;
using MoMoney.Modules.Core;
using momoney.service.infrastructure.threading;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.boot
{
    class start_the_application : Command
    {
        readonly IBackgroundThread thread;
        readonly ILoadPresentationModulesCommand command;
        readonly ICommandProcessor processor;

        public start_the_application(IBackgroundThread thread)
            : this(thread, Lazy.load<ILoadPresentationModulesCommand>(), Lazy.load<ICommandProcessor>()) {}

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