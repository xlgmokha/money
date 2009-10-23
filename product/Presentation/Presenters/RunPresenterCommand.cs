using MoMoney.Presentation.Core;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.Presentation.Presenters
{
    public class RunPresenterCommand : IRunPresenterCommand
    {
        readonly IApplicationController application_controller;
        readonly CommandProcessor processor;

        public RunPresenterCommand(IApplicationController application_controller, CommandProcessor processor)
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