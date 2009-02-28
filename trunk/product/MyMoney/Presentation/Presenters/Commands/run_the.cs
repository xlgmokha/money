using MyMoney.Presentation.Core;
using MyMoney.Utility.Core;

namespace MyMoney.Presentation.Presenters.Commands
{
    public interface IRunThe<Presenter> : ICommand where Presenter : IPresenter
    {}

    public class run_the<Presenter> : IRunThe<Presenter> where Presenter : IPresenter
    {
        private readonly IApplicationController applicationController;

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