using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.Core;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.updates;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.updates;
using MoMoney.Service.Infrastructure.Updating;
using MoMoney.Tasks.infrastructure.core;
using MoMoney.Tasks.infrastructure.updating;

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
        readonly IDownloadTheLatestVersion download_the_latest;
        readonly ICancelUpdate cancel_requested_update;
        readonly ICommandPump pump;

        public CheckForUpdatesPresenter(ICheckForUpdatesView view,
                                        ICommandPump pump,
                                        IRestartCommand command,
                                        IDownloadTheLatestVersion download_the_latest,
                                        ICancelUpdate cancel_requested_update)
        {
            this.pump = pump;
            this.view = view;
            this.cancel_requested_update = cancel_requested_update;
            this.download_the_latest = download_the_latest;
            this.command = command;
        }

        public void run()
        {
            pump.run<ApplicationVersion, IWhatIsTheAvailableVersion>(view);
            view.attach_to(this);
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
            if (completed.Equals(new Percent(100)))
            {
                view.update_complete();
                restart();
            }
            else view.downloaded(completed);
        }
    }
}