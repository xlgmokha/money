using MoMoney.Presentation.Core;
using momoney.presentation.views;
using momoney.service.infrastructure.logging;

namespace momoney.presentation.presenters
{
    public class LogFilePresenter : ContentPresenter<ILogFileView>
    {
        ILogFileTasks tasks;

        public LogFilePresenter(ILogFileView view, ILogFileTasks tasks) : base(view)
        {
            this.tasks = tasks;
        }

        protected override void present()
        {
            view.display(tasks.get_the_path_to_the_log_file());
            view.run(tasks.get_the_contents_of_the_log_file());
        }
    }
}