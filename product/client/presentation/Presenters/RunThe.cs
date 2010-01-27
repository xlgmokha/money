using gorilla.commons.utility;
using MoMoney.Presentation.Core;
using MoMoney.Service.Infrastructure.Threading;

namespace momoney.presentation.presenters
{
    public interface IRunThe<TPresenter> : Command where TPresenter : Presenter {}

    public class RunThe<TPresenter> : IRunThe<TPresenter> where TPresenter : Presenter
    {
        readonly IApplicationController controller;
        readonly CommandProcessor processor;

        public RunThe(IApplicationController controller, CommandProcessor processor)
        {
            this.controller = controller;
            this.processor = processor;
        }

        public void run()
        {
            processor.add(() => controller.run<TPresenter>());
        }
    }
}