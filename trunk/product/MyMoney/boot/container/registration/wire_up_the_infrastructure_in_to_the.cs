using Gorilla.Commons.Infrastructure.Eventing;
using Gorilla.Commons.Infrastructure.Registries;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Infrastructure.Transactions;
using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.Container;
//using MoMoney.Infrastructure.transactions;
using MoMoney.Presentation.Model.Projects;

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
            //registry.singleton<IUnitOfWorkRegistry, UnitOfWorkRegistry>();
            registry.singleton<IProjectController, ProjectController>();
            registry.transient(typeof (IRegistry<>), typeof (DefaultRegistry<>));
            //registry.transient(typeof (IUnitOfWorkRegistrationFactory<>), typeof (UnitOfWorkRegistrationFactory<>));

            registry.transient(typeof (ITrackerEntryMapper<>), typeof (TrackerEntryMapper<>));
            registry.transient(typeof (IKey<>), typeof (TypedKey<>));
            registry.transient(typeof (IComponentFactory<>), typeof (Factory<>));
            registry.singleton<IContext, Context>();
        }
    }
}