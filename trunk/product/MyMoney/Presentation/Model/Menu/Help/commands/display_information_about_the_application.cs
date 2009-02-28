using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Presenters.Menu.Help;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Model.Menu.Help.commands
{
    public interface IDisplayInformationAboutTheApplication : ICommand
    {
    }

    public class display_information_about_the_application : IDisplayInformationAboutTheApplication
    {
        public display_information_about_the_application(IRunPresenterCommand run_presenter)
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