using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using Gorilla.Commons.Utility;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using momoney.service.infrastructure.updating;

namespace momoney.presentation.presenters
{
    public class CheckForUpdatesPresenter : DialogPresenter, Callback<Percent>
    {
        readonly ICheckForUpdatesView view;
        readonly ICommandPump pump;

        public CheckForUpdatesPresenter(ICheckForUpdatesView view, ICommandPump pump)
        {
            this.pump = pump;
            this.view = view;
        }

        public void present(Shell shell)
        {
            pump.run<ApplicationVersion, IWhatIsTheAvailableVersion>(view);
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