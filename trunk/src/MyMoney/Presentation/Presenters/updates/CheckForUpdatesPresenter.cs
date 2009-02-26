using MyMoney.Presentation.Core;
using MyMoney.Presentation.Views.updates;
using MyMoney.Tasks.infrastructure;

namespace MyMoney.Presentation.Presenters.updates
{
    public interface ICheckForUpdatesPresenter : IPresenter
    {
    }

    public class CheckForUpdatesPresenter : ICheckForUpdatesPresenter
    {
        readonly ICheckForUpdatesView view;
        readonly IUpdateTasks tasks;

        public CheckForUpdatesPresenter(ICheckForUpdatesView view, IUpdateTasks tasks)
        {
            this.view = view;
            this.tasks = tasks;
        }

        public void run()
        {
            view.attach_to(this);
            view.display(tasks.current_application_version());
        }
    }
}