using MyMoney.Presentation.Core;

namespace MyMoney.Presentation.Presenters.Commands
{
    public interface IRunPresenterCommand
    {
        void execute<Presenter>() where Presenter : IPresenter;
    }

    public class run_presenter_command : IRunPresenterCommand
    {
        private readonly IApplicationController application_controller;

        public run_presenter_command(IApplicationController applicationController)
        {
            application_controller = applicationController;
        }

        public void execute<Presenter>() where Presenter : IPresenter
        {
            application_controller.run<Presenter>();
        }
    }
}