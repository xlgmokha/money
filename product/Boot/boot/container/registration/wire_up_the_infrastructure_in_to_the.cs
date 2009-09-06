using System.Collections;
using System.ComponentModel;
using System.Deployment.Application;
using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Infrastructure.Registries;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Infrastructure.Transactions;
using Gorilla.Commons.Utility.Core;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Service.Infrastructure.Eventing;
using MoMoney.Service.Infrastructure.Threading;
using MoMoney.Service.Infrastructure.Updating;
using MoMoney.Tasks.infrastructure.updating;

namespace MoMoney.boot.container.registration
{
    class wire_up_the_infrastructure_in_to_the : ICommand
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
            registry.singleton<IProjectController, ProjectController>();
            registry.transient(typeof (IRegistry<>), typeof (DefaultRegistry<>));
            registry.transient(typeof (ITrackerEntryMapper<>), typeof (TrackerEntryMapper<>));
            registry.transient(typeof (IKey<>), typeof (TypedKey<>));
            registry.transient(typeof (IComponentFactory<>), typeof (ComponentFactory<>));
            registry.singleton<IContext>(() => new Context(new Hashtable()));

            registry.singleton(() => AsyncOperationManager.SynchronizationContext);
            registry.singleton<AsyncOperation>(() => AsyncOperationManager.CreateOperation(new object()));
            registry.singleton<ApplicationDeployment>(
                () => ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment : null);
            registry.singleton<IDeployment>(
                () =>
                ApplicationDeployment.IsNetworkDeployed
                    ? (IDeployment) new CurrentDeployment()
                    : (IDeployment) new NullDeployment());

            registry.transient<ICommandPump, CommandPump>();
            registry.transient<ICommandFactory, CommandFactory>();
            registry.transient<ISynchronizationContextFactory, SynchronizationContextFactory>();
            registry.singleton<ICommandProcessor, AsynchronousCommandProcessor>();
        }
    }
}