using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Threading;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.updates;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.updates;
using MoMoney.Tasks.infrastructure;
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
        readonly ICommandProcessor processor;

        public CheckForUpdatesPresenter(ICheckForUpdatesView view, IUpdateTasks tasks, IRestartCommand command,
                                        ICommandProcessor processor)
        {
            this.view = view;
            this.processor = processor;
            this.tasks = tasks;
            this.command = command;
        }

        public void run()
        {
            view.attach_to(this);
            processor.add(
                new RunQueryCommand<ApplicationVersion>(
                    view,
                    new ProcessQueryCommand<ApplicationVersion>(new WhatIsTheAvailableVersion(tasks)))
                );
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

    public interface IProcessQueryCommand<T> : IParameterizedCommand<ICallback<T>>
    {
    }

    public class ProcessQueryCommand<T> : IProcessQueryCommand<T>
    {
        readonly IQuery<T> query;

        public ProcessQueryCommand(IQuery<T> query)
        {
            this.query = query;
        }

        public void run(ICallback<T> item)
        {
            item.run(query.fetch());
        }
    }

    public interface IRunQueryCommand<T> : ICommand
    {
    }

    public class RunQueryCommand<T> : IRunQueryCommand<T>
    {
        readonly ICallback<T> callback;
        readonly IProcessQueryCommand<T> command;

        public RunQueryCommand(ICallback<T> callback, IProcessQueryCommand<T> command)
        {
            this.callback = callback;
            this.command = command;
        }

        public void run()
        {
            command.run(callback);
        }
    }

    public class WhatIsTheAvailableVersion : IQuery<ApplicationVersion>
    {
        readonly IUpdateTasks tasks;

        public WhatIsTheAvailableVersion(IUpdateTasks tasks)
        {
            this.tasks = tasks;
        }

        public ApplicationVersion fetch()
        {
            return tasks.current_application_version();
        }
    }
}