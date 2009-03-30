using System.Deployment.Application;
using System.Threading;
using MoMoney.Presentation.Model.updates;
using MoMoney.Utility.Core;

namespace MoMoney.Tasks.infrastructure.updating
{
    public interface IWhatIsTheAvailableVersion : IQuery<ApplicationVersion>
    {
    }

    public class WhatIsTheAvailableVersion : IWhatIsTheAvailableVersion
    {
        readonly ApplicationDeployment deployment;

        public WhatIsTheAvailableVersion(ApplicationDeployment deployment)
        {
            this.deployment = deployment;
        }

        public ApplicationVersion fetch()
        {
            if (null == deployment)
            {
                Thread.Sleep(5000);
                return new ApplicationVersion {updates_available = false,};
            }

            var update = deployment.CheckForDetailedUpdate();
            return new ApplicationVersion
                       {
                           activation_url = deployment.ActivationUri,
                           current = deployment.CurrentVersion,
                           data_directory = deployment.DataDirectory,
                           updates_available = update.IsUpdateRequired || update.UpdateAvailable,
                           last_checked_for_updates = deployment.TimeOfLastUpdateCheck,
                           application_name = deployment.UpdatedApplicationFullName,
                           deployment_url = deployment.UpdateLocation,
                           available_version = update.AvailableVersion,
                           size_of_update_in_bytes = update.UpdateSizeBytes,
                       };
        }
    }
}