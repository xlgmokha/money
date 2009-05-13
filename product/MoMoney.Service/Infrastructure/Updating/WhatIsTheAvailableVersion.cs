using Gorilla.Commons.Utility.Core;
using MoMoney.DTO;
using MoMoney.Tasks.infrastructure.updating;

namespace MoMoney.Service.Infrastructure.Updating
{
    public interface IWhatIsTheAvailableVersion : IQuery<ApplicationVersion>
    {
    }

    public class WhatIsTheAvailableVersion : IWhatIsTheAvailableVersion
    {
        readonly IDeployment deployment;

        public WhatIsTheAvailableVersion(IDeployment deployment)
        {
            this.deployment = deployment;
        }

        public ApplicationVersion fetch()
        {
            var update = deployment.CheckForDetailedUpdate();
            if (null == update)
            {
                return new ApplicationVersion {updates_available = false,};
            }
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