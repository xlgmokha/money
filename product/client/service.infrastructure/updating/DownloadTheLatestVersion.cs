using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using momoney.service.infrastructure.updating;

namespace MoMoney.Service.Infrastructure.Updating
{
    public class DownloadTheLatestVersion : IDownloadTheLatestVersion
    {
        readonly IDeployment deployment;

        public DownloadTheLatestVersion(IDeployment deployment)
        {
            this.deployment = deployment;
        }

        public void run_against(Callback<Percent> callback)
        {
            deployment.UpdateProgressChanged += (o, e) => callback.run_against(new Percent(e.BytesCompleted, e.BytesTotal));
            deployment.UpdateCompleted += (sender, args) => callback.run_against(100);
            deployment.UpdateAsync();
        }
    }
}