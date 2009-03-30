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
        readonly IRestartCommand command;
        readonly IDisplayNextAvailableVersion display_version_command;
        readonly IDownloadTheLatestVersion download_the_latest;
        readonly ICancelUpdate cancel_requested_update;

        public CheckForUpdatesPresenter(ICheckForUpdatesView view,
                                        IRestartCommand command,
                                        IDisplayNextAvailableVersion display_version_command,
                                        IDownloadTheLatestVersion download_the_latest,
                                        ICancelUpdate cancel_requested_update)
        {
            this.view = view;
            this.cancel_requested_update = cancel_requested_update;
            this.download_the_latest = download_the_latest;
            this.display_version_command = display_version_command;
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
            download_the_latest.run(this);
        }

        public void cancel_update()
        {
            cancel_requested_update.run();
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