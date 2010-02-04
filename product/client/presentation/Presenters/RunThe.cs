using gorilla.commons.utility;
using MoMoney.Presentation.Core;

namespace momoney.presentation.presenters
{
    public interface IRunThe<TPresenter> : Command where TPresenter : Presenter {}

    public class RunThe<TPresenter> : IRunThe<TPresenter> where TPresenter : Presenter
    {
        readonly IApplicationController controller;

        public RunThe(IApplicationController controller)
        {
            this.controller = controller;
        }

        public void run()
        {
            controller.run<TPresenter>();
        }
    }
}