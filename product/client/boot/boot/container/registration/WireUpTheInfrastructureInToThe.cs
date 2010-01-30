using System.ComponentModel;
using System.Deployment.Application;
using Gorilla.Commons.Infrastructure.Reflection;
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
    class WireUpTheInfrastructureInToThe : IStartupCommand
    {
        readonly DependencyRegistration registry;

        public WireUpTheInfrastructureInToThe(DependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run(Assembly item)
        {
            registry.singleton<EventAggregator, SynchronizedEventAggregator>();
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
            registry.transient<CommandFactory, SynchronizedCommandFactory>();
            registry.transient<ISynchronizationContextFactory, SynchronizationContextFactory>();
            registry.singleton<CommandProcessor, AsynchronousCommandProcessor>();
        }
    }
}