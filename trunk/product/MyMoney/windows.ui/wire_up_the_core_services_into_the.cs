using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Utility.Core;

namespace MoMoney.windows.ui
{
    internal class wire_up_the_core_services_into_the : ICommand
    {
        private readonly windsor_dependency_registry registry;

        public wire_up_the_core_services_into_the(windsor_dependency_registry registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            resolve.initialize_with(registry);
        }
    }
}