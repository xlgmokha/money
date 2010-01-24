using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters;
using momoney.presentation.views;
using momoney.service.infrastructure.updating;

namespace momoney.presentation.presenters
{
    public interface ICheckForUpdatesPresenter : IPresenter, Callback<Percent>
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

        public void present()
        {
            pump.run<ApplicationVersion, IWhatIsTheAvailableVersion>(view);
            view.attach_to(this);
            view.display();
        }

        public void begin_update()
        {
            pump.run<IDownloadTheLatestVersion, Callback<Percent>>(this);
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