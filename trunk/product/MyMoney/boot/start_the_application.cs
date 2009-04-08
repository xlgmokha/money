using System;
using System.ComponentModel;
using System.ComponentModel.Design;
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

    public class ApplicationContainer : Container
    {
        readonly IServiceContainer container;

        public ApplicationContainer() : this(new ServiceContainer())
        {
        }

        public ApplicationContainer(IServiceContainer container)
        {
            this.container = container;
        }

        protected override object GetService(Type service)
        {
            return container.GetService(service) ?? base.GetService(service);
        }
    }
}