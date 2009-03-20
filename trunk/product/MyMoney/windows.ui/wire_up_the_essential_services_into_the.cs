using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.Logging;
using MoMoney.Infrastructure.Logging.Log4NetLogging;
using MoMoney.Utility.Core;

namespace MoMoney.windows.ui
{
    internal class wire_up_the_essential_services_into_the : ICommand
    {
        readonly WindsorDependencyRegistry registry;

        public wire_up_the_essential_services_into_the(WindsorDependencyRegistry registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            resolve.initialize_with(registry);
            registry.singleton<ILogFactory, Log4NetLogFactory>();
        }
    }
}