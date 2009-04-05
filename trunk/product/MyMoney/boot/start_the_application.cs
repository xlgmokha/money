using System;
using System.Windows.Forms;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Infrastructure.Threading;
using MoMoney.Modules.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Utility.Core;

namespace MoMoney.boot
{
    internal class start_the_application : ICommand
    {
        ILoadPresentationModulesCommand command;
        ICommandProcessor processor;

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
            try
            {
                processor.run();
                command.run();
                Application.Run(resolve.dependency_for<ApplicationShell>());
            }
            catch (Exception e)
            {
                this.log().error(e);
                resolve.dependency_for<IEventAggregator>().publish(new unhandled_error_occurred(e));
            }
        }
    }
}