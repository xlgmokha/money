using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views.Navigation;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.Navigation
{
    public interface IMainMenuPresenter : IPresentationModule, IEventSubscriber<new_project_opened>
    {
    }

    public class MainMenuPresenter : IMainMenuPresenter
    {
        readonly IMainMenuView view;
        readonly IRegistry<IActionTaskPaneFactory> registry;
        readonly IEventAggregator broker;

        public MainMenuPresenter(IMainMenuView view, IRegistry<IActionTaskPaneFactory> registry, IEventAggregator broker)
        {
            this.view = view;
            this.broker = broker;
            this.registry = registry;
        }

        public void run()
        {
            broker.subscribe_to(this);
            registry.all().each(x => view.add(x.create()));
        }

        public void notify(new_project_opened message)
        {
            view.display();
        }
    }
}