using System;
using System.ComponentModel;
using System.Deployment.Application;
using MoMoney.Service.Infrastructure.Updating;

namespace momoney.service.infrastructure.updating
{
    public class CurrentDeployment : IDeployment
    {
        readonly ApplicationDeployment deployment;

        public CurrentDeployment()
        {
            deployment = ApplicationDeployment.CurrentDeployment;
        }

        public UpdateCheckInfo CheckForDetailedUpdate()
        {
            return deployment.CheckForDetailedUpdate();
        }

        public UpdateCheckInfo CheckForDetailedUpdate(bool persistUpdateCheckResult)
        {
            return deployment.CheckForDetailedUpdate(persistUpdateCheckResult);
        }

        public bool CheckForUpdate()
        {
            return deployment.CheckForUpdate();
        }

        public bool CheckForUpdate(bool persistUpdateCheckResult)
        {
            return deployment.CheckForUpdate(persistUpdateCheckResult);
        }

        public void CheckForUpdateAsync()
        {
            deployment.CheckForUpdateAsync();
        }

        public void CheckForUpdateAsyncCancel()
        {
            deployment.CheckForUpdateAsyncCancel();
        }

        public bool Update()
        {
            return deployment.Update();
        }

        public void UpdateAsync()
        {
            deployment.UpdateAsync();
        }

        public void UpdateAsyncCancel()
        {
            deployment.UpdateAsyncCancel();
        }

        public void DownloadFileGroup(string groupName)
        {
            deployment.DownloadFileGroup(groupName);
        }

        public void DownloadFileGroupAsync(string groupName)
        {
            deployment.DownloadFileGroupAsync(groupName);
        }

        public void DownloadFileGroupAsync(string groupName, object userState)
        {
            deployment.DownloadFileGroupAsync(groupName, userState);
        }

        public bool IsFileGroupDownloaded(string groupName)
        {
            return deployment.IsFileGroupDownloaded(groupName);
        }

        public void DownloadFileGroupAsyncCancel(string groupName)
        {
            deployment.DownloadFileGroupAsyncCancel(groupName);
        }

        public Version CurrentVersion
        {
            get { return deployment.CurrentVersion; }
        }

        public Version UpdatedVersion
        {
            get { return deployment.UpdatedVersion; }
        }

        public string UpdatedApplicationFullName
        {
            get { return deployment.UpdatedApplicationFullName; }
        }

        public DateTime TimeOfLastUpdateCheck
        {
            get { return deployment.TimeOfLastUpdateCheck; }
        }

        public Uri UpdateLocation
        {
            get { return deployment.UpdateLocation; }
        }

        public Uri ActivationUri
        {
            get { return deployment.ActivationUri; }
        }

        public string DataDirectory
        {
            get { return deployment.DataDirectory; }
        }

        public bool IsFirstRun
        {
            get { return deployment.IsFirstRun; }
        }

        public event DeploymentProgressChangedEventHandler CheckForUpdateProgressChanged
        {
            add { deployment.CheckForUpdateProgressChanged += value; }
            remove { deployment.CheckForUpdateProgressChanged -= value; }
        }

        public event CheckForUpdateCompletedEventHandler CheckForUpdateCompleted
        {
            add { deployment.CheckForUpdateCompleted += value; }
            remove { deployment.CheckForUpdateCompleted -= value; }
        }

        public event DeploymentProgressChangedEventHandler UpdateProgressChanged
        {
            add { deployment.UpdateProgressChanged += value; }
            remove { deployment.UpdateProgressChanged -= value; }
        }

        public event AsyncCompletedEventHandler UpdateCompleted
        {
            add { deployment.UpdateCompleted += value; }
            remove { deployment.UpdateCompleted -= value; }
        }

        public event DeploymentProgressChangedEventHandler DownloadFileGroupProgressChanged
        {
            add { deployment.DownloadFileGroupProgressChanged += value; }
            remove { deployment.DownloadFileGroupProgressChanged -= value; }
        }

        public event DownloadFileGroupCompletedEventHandler DownloadFileGroupCompleted
        {
            add { deployment.DownloadFileGroupCompleted += value; }
            remove { deployment.DownloadFileGroupCompleted -= value; }
        }
    }
}