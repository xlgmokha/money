using MoMoney.Infrastructure.Threading;
using MoMoney.Presentation.Core;

namespace MoMoney.Presentation.Presenters.Commands
{
    public interface IRunPresenterCommand
    {
        void run<Presenter>() where Presenter : IPresenter;
    }

    public class RunPresenterCommand : IRunPresenterCommand
    {
        readonly IApplicationController application_controller;
        readonly ICommandProcessor processor;

        public RunPresenterCommand(IApplicationController application_controller, ICommandProcessor processor)
        {
            this.application_controller = application_controller;
            this.processor = processor;
        }

        public void run<Presenter>() where Presenter : IPresenter
        {
            processor.add(() => application_controller.run<Presenter>());
        }
    }
}