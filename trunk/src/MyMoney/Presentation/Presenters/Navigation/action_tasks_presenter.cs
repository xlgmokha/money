using MyMoney.Presentation.Presenters.Shell;
using MyMoney.Presentation.Views.Navigation;

namespace MyMoney.Presentation.Presenters.Navigation
{
    public interface IActionTasksPresenter : IPresentationModule
    {
    }

    public class action_tasks_presenter : IActionTasksPresenter
    {
        readonly IActionsTaskView view;

        public action_tasks_presenter(IActionsTaskView view)
        {
            this.view = view;
        }

        public void run()
        {
            view.display();
        }
    }
}