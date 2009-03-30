using MoMoney.Utility.Core;

namespace MoMoney.Tasks.infrastructure.updating
{
    public interface ICancelUpdate : ICommand
    {
    }

    public class CancelUpdate : ICancelUpdate
    {
        readonly IDeployment deployment;

        public CancelUpdate(IDeployment deployment)
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