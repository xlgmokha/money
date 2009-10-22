using gorilla.commons.utility;
using momoney.presentation.presenters;
using MoMoney.Presentation.Presenters;

namespace MoMoney.Presentation.model.menu.help
{
    public interface IDisplayInformationAboutTheApplication : Command {}

    public class DisplayInformationAboutTheApplication : IDisplayInformationAboutTheApplication
    {
        public DisplayInformationAboutTheApplication(IRunPresenterCommand run_presenter)
        {
            this.run_presenter = run_presenter;
        }

        public void run()
        {
            run_presenter.run<IAboutApplicationPresenter>();
        }

        readonly IRunPresenterCommand run_presenter;
    }
}