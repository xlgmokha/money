using System.ComponentModel;
using System.Deployment.Application;
using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Log4Net;
using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Utility.Core;
using MoMoney.Tasks.infrastructure.updating;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_essential_services_into_the : ICommand
    {
        readonly IDependencyRegistration registration;

        public wire_up_the_essential_services_into_the(IDependencyRegistration registration)
        {
            this.registration = registration;
        }

        public void run()
        {
            registration.singleton<IDependencyRegistration>(() => registration);
            registration.singleton<IDependencyRegistry>(() => registration.build());
            registration.singleton<ILogFactory, Log4NetLogFactory>();
            registration.singleton<ICommandProcessor, AsynchronousCommandProcessor>();
            registration.singleton(() => AsyncOperationManager.SynchronizationContext);
            registration.singleton<AsyncOperation>(() => AsyncOperationManager.CreateOperation(new object()));
            registration.singleton<ApplicationDeployment>( () => ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment : null);
            registration.singleton<IDeployment>( () => ApplicationDeployment.IsNetworkDeployed ? (IDeployment) new CurrentDeployment() : (IDeployment) new NullDeployment());
        }
    }
}