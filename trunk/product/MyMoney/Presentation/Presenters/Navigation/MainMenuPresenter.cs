using MoMoney.Domain.Core;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.Navigation;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.Navigation
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