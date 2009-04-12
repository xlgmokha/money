using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.Navigation;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.Navigation
{
    public interface IMainMenuPresenter : IContentPresenter
    {
    }

    public class MainMenuPresenter : ContentPresenter<IMainMenuView>, IMainMenuPresenter
    {
        readonly IRegistry<IActionTaskPaneFactory> registry;

        public MainMenuPresenter(IMainMenuView view, IRegistry<IActionTaskPaneFactory> registry) : base(view)
        {
            this.registry = registry;
        }

        public override void run()
        {
            registry.all().each(x => view.add(x));
        }
    }
}