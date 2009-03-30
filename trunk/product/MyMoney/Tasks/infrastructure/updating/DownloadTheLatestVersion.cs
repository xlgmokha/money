using System.Deployment.Application;
using MoMoney.Domain.Core;
using MoMoney.Tasks.infrastructure.core;
using MoMoney.Utility.Core;

namespace MoMoney.Tasks.infrastructure.updating
{
    public interface IDownloadTheLatestVersion : ICallbackCommand<Percent>
    {
    }

    public class DownloadTheLatestVersion : IDownloadTheLatestVersion
    {
        readonly ApplicationDeployment deployment;

        public DownloadTheLatestVersion(ApplicationDeployment deployment)
        {
            this.deployment = deployment;
        }

        public void run(ICallback<Percent> callback)
        {
            deployment.UpdateProgressChanged += (o, e) => callback.run(new Percent(e.BytesCompleted, e.BytesTotal));
            deployment.UpdateCompleted += (sender, args) => callback.run(100);
            deployment.UpdateAsync();
        }
    }
}