using System.Deployment.Application;
using MoMoney.Utility.Core;

namespace MoMoney.Tasks.infrastructure.updating
{
    public interface ICancelUpdate : ICommand
    {
    }

    public class CancelUpdate : ICancelUpdate
    {
        readonly ApplicationDeployment deployment;

        public CancelUpdate(ApplicationDeployment deployment)
        {
            this.deployment = deployment;
        }

        public void run()
        {
            if (null == deployment) return;
            deployment.UpdateAsyncCancel();
        }
    }
}