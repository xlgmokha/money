using System;
using MyMoney.Presentation.Core;
using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Views.updates;
using MyMoney.Tasks.infrastructure;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Presenters.updates
{
    public interface ICheckForUpdatesPresenter : IPresenter, ICallback
    {
        void begin_update();
        void cancel_update();
        void restart();
        void do_not_update();
    }

    public class CheckForUpdatesPresenter : ICheckForUpdatesPresenter
    {
        private readonly ICheckForUpdatesView view;
        private readonly IUpdateTasks tasks;
        private readonly IRestartCommand command;

        public CheckForUpdatesPresenter(ICheckForUpdatesView view, IUpdateTasks tasks, IRestartCommand command)
        {
            this.view = view;
            this.tasks = tasks;
            this.command = command;
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

        public void cancel_update()
        {
            tasks.stop_updating();
        }

        public void restart()
        {
            command.run();
        }

        public void do_not_update()
        {
            view.close();
        }

        public void complete()
        {
            view.update_complete();
        }
    }
}