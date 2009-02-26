using MyMoney.Presentation.Core;
using MyMoney.Presentation.Views.updates;
using MyMoney.Tasks.infrastructure;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Presenters.updates
{
    public interface ICheckForUpdatesPresenter : IPresenter, ICallback
    {
        void begin_update();
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

        public void begin_update()
        {
            tasks.grab_the_latest_version(this);
        }

        public void complete()
        {
            view.update_complete();
        }
    }
}