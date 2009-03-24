using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.registries;
using MoMoney.Infrastructure.Threading;
using MoMoney.Infrastructure.transactions;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Utility.Core;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_infrastructure_in_to_the : ICommand
    {
        readonly IDependencyRegistration registry;

        public wire_up_the_infrastructure_in_to_the(IDependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.singleton<IEventAggregator, EventAggregator>();
            registry.singleton<ITimer, IntervalTimer>();
            registry.singleton<IUnitOfWorkRegistry, UnitOfWorkRegistry>();
            registry.singleton<IProject, CurrentProject>();
            registry.transient(typeof (IRegistry<>), typeof (DefaultRegistry<>));
            registry.transient(typeof (IUnitOfWorkRegistrationFactory<>), typeof (UnitOfWorkRegistrationFactory<>));
        }
    }
}