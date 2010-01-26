using System.ComponentModel;
using System.Deployment.Application;
using Gorilla.Commons.Infrastructure.Registries;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.utility;
using momoney.database.transactions;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Presenters;
using MoMoney.Service.Infrastructure.Eventing;
using momoney.service.infrastructure.threading;
using MoMoney.Service.Infrastructure.Threading;
using momoney.service.infrastructure.updating;
using MoMoney.Service.Infrastructure.Updating;

namespace MoMoney.boot.container.registration
{
    class wire_up_the_infrastructure_in_to_the : Command
    {
        readonly DependencyRegistration registry;

        public wire_up_the_infrastructure_in_to_the(DependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.singleton<IEventAggregator, EventAggregator>();
            registry.singleton<ITimer, IntervalTimer>();
            registry.singleton<IProjectController, ProjectController>();
            registry.transient(typeof (Registry<>), typeof (DefaultRegistry<>));
            registry.transient(typeof (ITrackerEntryMapper<>), typeof (TrackerEntryMapper<>));
            registry.transient(typeof (IKey<>), typeof (TypedKey<>));
            registry.transient(typeof (ComponentFactory<>), typeof (DefaultConstructorFactory<>));
            //registry.singleton<IContext>(() => new Context(new Hashtable()));
            registry.singleton<IContext>(() => new PerThread());

            registry.singleton(() => AsyncOperationManager.SynchronizationContext);
            registry.singleton(() => AsyncOperationManager.CreateOperation(new object()));
            registry.singleton(
                () => ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment : null);
            registry.singleton(
                () =>
                ApplicationDeployment.IsNetworkDeployed
                    ? (IDeployment) new CurrentDeployment()
                    : (IDeployment) new NullDeployment());

            registry.transient<ICommandPump, CommandPump>();
            registry.transient<ICommandFactory, CommandFactory>();
            registry.transient<ISynchronizationContextFactory, SynchronizationContextFactory>();
            registry.singleton<CommandProcessor, AsynchronousCommandProcessor>();
        }
    }
}