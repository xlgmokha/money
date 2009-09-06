using MoMoney.Presentation.Core;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.Presentation.Presenters
{
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