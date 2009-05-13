using System;
using System.ComponentModel;
using System.Deployment.Application;

namespace MoMoney.Tasks.infrastructure.updating
{
    public interface IDeployment
    {
        UpdateCheckInfo CheckForDetailedUpdate();
        UpdateCheckInfo CheckForDetailedUpdate(bool persistUpdateCheckResult);
        bool CheckForUpdate();
        bool CheckForUpdate(bool persistUpdateCheckResult);
        void CheckForUpdateAsync();
        void CheckForUpdateAsyncCancel();
        bool Update();
        void UpdateAsync();
        void UpdateAsyncCancel();
        void DownloadFileGroup(string groupName);
        void DownloadFileGroupAsync(string groupName);
        void DownloadFileGroupAsync(string groupName, object userState);
        bool IsFileGroupDownloaded(string groupName);
        void DownloadFileGroupAsyncCancel(string groupName);
        Version CurrentVersion { get; }
        Version UpdatedVersion { get; }
        string UpdatedApplicationFullName { get; }
        DateTime TimeOfLastUpdateCheck { get; }
        Uri UpdateLocation { get; }
        Uri ActivationUri { get; }
        string DataDirectory { get; }
        bool IsFirstRun { get; }
        //event DeploymentProgressChangedEventHandler CheckForUpdateProgressChanged;
        //event CheckForUpdateCompletedEventHandler CheckForUpdateCompleted;
        event DeploymentProgressChangedEventHandler UpdateProgressChanged;
        event AsyncCompletedEventHandler UpdateCompleted;
        //event DeploymentProgressChangedEventHandler DownloadFileGroupProgressChanged;
        //event DownloadFileGroupCompletedEventHandler DownloadFileGroupCompleted;
    }
}