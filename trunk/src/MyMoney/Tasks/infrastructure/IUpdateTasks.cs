using MyMoney.Presentation.Model.updates;
using MyMoney.Utility.Core;

namespace MyMoney.Tasks.infrastructure
{
    public interface IUpdateTasks
    {
        ApplicationVersion current_application_version();
        void grab_the_latest_version(ICallback callback);
    }
}