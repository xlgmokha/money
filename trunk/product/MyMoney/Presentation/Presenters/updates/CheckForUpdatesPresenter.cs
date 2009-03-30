using MoMoney.Domain.Core;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.updates;
using MoMoney.Tasks.infrastructure.updating;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Presenters.updates
{
    public interface ICheckForUpdatesPresenter : IPresenter, ICallback<Percent>
    {
        void begin_update();
        void cancel_update();
        void restart();
        void do_not_update();
    }

    public class CheckForUpdatesPresenter : ICheckForUpdatesPresenter
    {
        readonly ICheckForUpdatesView view;
        readonly IUpdateTasks tasks;
        readonly IRestartCommand command;
        readonly IDisplayNextAvailableVersion display_version_command;

        public CheckForUpdatesPresenter(ICheckForUpdatesView view, IUpdateTasks tasks, IRestartCommand command,
                                        IDisplayNextAvailableVersion display_version_command)
        {
            this.view = view;
            this.display_version_command = display_version_command;
            this.tasks = tasks;
            this.command = command;
        }

        public void run()
        {
            view.attach_to(this);
            display_version_command.run(view);
            view.display();
        }

        public void begin_update()
        {
            tasks.grab_the_latest_version(this);
        }

        public void cancel_update()
        {
            tasks.stop_updating();
            view.close();
        }

        public void restart()
        {
            command.run();
        }

        public void do_not_update()
        {
            view.close();
        }

        public void run(Percent completed)
        {
            if (completed.Equals(new Percent(100))) view.update_complete();
            else view.downloaded(completed);
        }
    }
}