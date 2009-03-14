using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Tasks.infrastructure;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface ILogFilePresenter : IContentPresenter
    {
    }

    public class LogFilePresenter : ILogFilePresenter
    {
        readonly ILogFileView view;
        readonly ILogFileTasks tasks;

        public LogFilePresenter(ILogFileView view, ILogFileTasks tasks)
        {
            this.view = view;
            this.tasks = tasks;
        }

        public void run()
        {
            view.display(tasks.get_the_path_to_the_log_file(), tasks.get_the_contents_of_the_log_file());
        }

        IDockedContentView IContentPresenter.View
        {
            get { return view; }
        }
    }
}