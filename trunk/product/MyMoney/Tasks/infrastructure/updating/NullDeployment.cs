using System;
using System.ComponentModel;
using System.Deployment.Application;
using System.Threading;

namespace MoMoney.Tasks.infrastructure.updating
{
    public class NullDeployment : IDeployment
    {
        public UpdateCheckInfo CheckForDetailedUpdate()
        {
            Thread.Sleep(5000);
            return null;
        }

        public UpdateCheckInfo CheckForDetailedUpdate(bool persistUpdateCheckResult)
        {
            throw new NotImplementedException();
        }

        public bool CheckForUpdate()
        {
            return false;
        }

        public bool CheckForUpdate(bool persistUpdateCheckResult)
        {
            return false;
        }

        public void CheckForUpdateAsync()
        {
        }

        public void CheckForUpdateAsyncCancel()
        {
        }

        public bool Update()
        {
            return false;
        }

        public void UpdateAsync()
        {
        }

        public void UpdateAsyncCancel()
        {
        }

        public void DownloadFileGroup(string groupName)
        {
        }

        public void DownloadFileGroupAsync(string groupName)
        {
        }

        public void DownloadFileGroupAsync(string groupName, object userState)
        {
        }

        public bool IsFileGroupDownloaded(string groupName)
        {
            return false;
        }

        public void DownloadFileGroupAsyncCancel(string groupName)
        {
        }

        public Version CurrentVersion
        {
            get { throw new NotImplementedException(); }
        }

        public Version UpdatedVersion
        {
            get { throw new NotImplementedException(); }
        }

        public string UpdatedApplicationFullName
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime TimeOfLastUpdateCheck
        {
            get { throw new NotImplementedException(); }
        }

        public Uri UpdateLocation
        {
            get { throw new NotImplementedException(); }
        }

        public Uri ActivationUri
        {
            get { throw new NotImplementedException(); }
        }

        public string DataDirectory
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsFirstRun
        {
            get { throw new NotImplementedException(); }
        }

        public event DeploymentProgressChangedEventHandler CheckForUpdateProgressChanged;
        public event CheckForUpdateCompletedEventHandler CheckForUpdateCompleted;
        public event DeploymentProgressChangedEventHandler UpdateProgressChanged;
        public event AsyncCompletedEventHandler UpdateCompleted;
        public event DeploymentProgressChangedEventHandler DownloadFileGroupProgressChanged;
        public event DownloadFileGroupCompletedEventHandler DownloadFileGroupCompleted;
    }
}