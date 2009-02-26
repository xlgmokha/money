using MyMoney.Presentation.Model.updates;

namespace MyMoney.Tasks.infrastructure
{
    public interface IUpdateTasks
    {
        ApplicationVersion current_application_version();
    }
}