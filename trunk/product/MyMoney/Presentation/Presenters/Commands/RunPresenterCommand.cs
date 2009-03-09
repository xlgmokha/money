using MoMoney.Presentation.Core;

namespace MoMoney.Presentation.Presenters.Commands
{
    public interface IRunPresenterCommand
    {
        void run<Presenter>() where Presenter : IPresenter;
    }

    public class RunPresenterCommand : IRunPresenterCommand
    {
        private readonly IApplicationController application_controller;

        public RunPresenterCommand(IApplicationController applicationController)
        {
            application_controller = applicationController;
        }

        public void run<Presenter>() where Presenter : IPresenter
        {
            application_controller.run<Presenter>();
        }
    }
}