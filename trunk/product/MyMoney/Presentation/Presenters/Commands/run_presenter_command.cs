using MoMoney.Presentation.Core;

namespace MoMoney.Presentation.Presenters.Commands
{
    public interface IRunPresenterCommand
    {
        void run<Presenter>() where Presenter : IPresenter;
    }

    public class run_presenter_command : IRunPresenterCommand
    {
        private readonly IApplicationController application_controller;

        public run_presenter_command(IApplicationController applicationController)
        {
            application_controller = applicationController;
        }

        public void run<Presenter>() where Presenter : IPresenter
        {
            application_controller.run<Presenter>();
        }
    }
}