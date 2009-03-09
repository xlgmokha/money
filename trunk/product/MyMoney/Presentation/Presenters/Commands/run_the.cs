using MoMoney.Presentation.Core;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Presenters.Commands
{
    public interface IRunThe<Presenter> : ICommand where Presenter : IPresenter
    {
    }

    public class run_the<Presenter> : IRunThe<Presenter> where Presenter : IPresenter
    {
        readonly IApplicationController applicationController;

        public run_the(IApplicationController applicationController)
        {
            this.applicationController = applicationController;
        }

        public void run()
        {
            applicationController.run<Presenter>();
        }
    }
}