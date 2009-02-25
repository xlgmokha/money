using MyMoney.Domain.Core;
using MyMoney.Presentation.Presenters.Shell;
using MyMoney.Presentation.Views.Navigation;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Presenters.Navigation
{
    public interface IActionTasksPresenter : IPresentationModule
    {
    }

    public class action_tasks_presenter : IActionTasksPresenter
    {
        readonly IActionsTaskView view;
        readonly IRegistry<IActionTaskPaneFactory> registry;

        public action_tasks_presenter(IActionsTaskView view, IRegistry<IActionTaskPaneFactory> registry)
        {
            this.view = view;
            this.registry = registry;
        }

        public void run()
        {
            view.display();
            registry.all().each(x => view.add(x.create()));
        }
    }
}