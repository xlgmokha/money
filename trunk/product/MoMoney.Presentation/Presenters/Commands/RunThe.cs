using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Utility.Core;
using MoMoney.Presentation.Core;

namespace MoMoney.Presentation.Presenters.Commands
{
    public interface IRunThe<Presenter> : ICommand where Presenter : IPresenter
    {
    }

    public class RunThe<Presenter> : IRunThe<Presenter> where Presenter : IPresenter
    {
        readonly IApplicationController application_controller;
        readonly ICommandProcessor processor;

        public RunThe(IApplicationController application_controller, ICommandProcessor processor)
        {
            this.application_controller = application_controller;
            this.processor = processor;
        }

        public void run()
        {
            processor.add(() => application_controller.run<Presenter>());
        }
    }
}