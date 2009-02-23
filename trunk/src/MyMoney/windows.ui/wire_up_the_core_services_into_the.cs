using MyMoney.Infrastructure.Container;
using MyMoney.Infrastructure.Container.Windsor;
using MyMoney.Utility.Core;

namespace MyMoney.windows.ui
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