using System.ComponentModel;
using System.Deployment.Application;
using System.Threading;
using System.Windows.Forms;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.Logging;
using MoMoney.Infrastructure.Logging.Log4NetLogging;
using MoMoney.Infrastructure.Threading;
using MoMoney.Tasks.infrastructure.updating;
using MoMoney.Utility.Core;

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
            registration.singleton(
                () =>
                    {
                        return AsyncOperationManager.SynchronizationContext;
                        //if (SynchronizationContext.Current == null)
                        //{
                        //    SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
                        //}
                        //return SynchronizationContext.Current;
                    });
            registration.singleton<AsyncOperation>(() => AsyncOperationManager.CreateOperation(null));
            registration.singleton<ApplicationDeployment>(() => ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment : null);
            registration.singleton<IDeployment>(() => ApplicationDeployment.IsNetworkDeployed ? (IDeployment)new CurrentDeployment() : (IDeployment)new NullDeployment());
        }
    }
}