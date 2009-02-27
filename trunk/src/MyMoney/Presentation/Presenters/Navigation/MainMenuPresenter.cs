using MyMoney.Domain.Core;
using MyMoney.Presentation.Core;
using MyMoney.Presentation.Views.Navigation;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Presenters.Navigation
{
    public interface IMainMenuPresenter : IPresentationModule
    {
    }

    public class MainMenuPresenter : IMainMenuPresenter
    {
        readonly IMainMenuView view;
        readonly IRegistry<IActionTaskPaneFactory> registry;

        public MainMenuPresenter(IMainMenuView view, IRegistry<IActionTaskPaneFactory> registry)
        {
            this.view = view;
            this.registry = registry;
        }

        public void run()
        {
            registry.all().each(x => view.add(x.create()));
            view.display();
        }
    }
}