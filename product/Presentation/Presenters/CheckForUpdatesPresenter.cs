using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Utility;
using Gorilla.Commons.Utility.Core;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.updates;
using MoMoney.Service.Contracts.Infrastructure.Updating;
using MoMoney.Service.Infrastructure.Updating;
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
        readonly ICommandPump pump;

        public CheckForUpdatesPresenter(ICheckForUpdatesView view, ICommandPump pump)
        {
            this.pump = pump;
            this.view = view;
        }

        public void run()
        {
            pump.run<ApplicationVersion, IWhatIsTheAvailableVersion>(view);
            view.attach_to(this);
            view.display();
        }

        public void begin_update()
        {
            pump.run<IDownloadTheLatestVersion, ICallback<Percent>>(this);
        }

        public void cancel_update()
        {
            pump.run<ICancelUpdate>();
            view.close();
        }

        public void restart()
        {
            pump.run<IRestartCommand>();
        }

        public void do_not_update()
        {
            view.close();
        }

        public void run(Percent completed)
        {
            if (completed.Equals(new Percent(100)))
            {
                this.log().debug("completed download");
                view.update_complete();
                restart();
            }
            else
            {
                this.log().debug("completed {0}", completed);
                view.downloaded(completed);
            }
        }
    }
}