using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Service.Infrastructure.Logging;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface ILogFilePresenter : IContentPresenter
    {
    }

    public class LogFilePresenter : ContentPresenter<ILogFileView>, ILogFilePresenter
    {
        readonly ILogFileTasks tasks;

        public LogFilePresenter(ILogFileView view, ILogFileTasks tasks) : base(view)
        {
            this.tasks = tasks;
        }

        public override void run()
        {
            view.display(tasks.get_the_path_to_the_log_file());
            view.run(tasks.get_the_contents_of_the_log_file());
            //tasks.notify(view);
        }
    }
}