using MoMoney.Presentation;
using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public class UnhandledErrorPresenter : IModule, IPresenter, IEventSubscriber<UnhandledErrorOccurred>
    {
        readonly IUnhandledErrorView view;
        readonly IEventAggregator broker;
        readonly IRestartCommand restart;

        public UnhandledErrorPresenter(IUnhandledErrorView view, IEventAggregator broker, IRestartCommand command)
        {
            this.view = view;
            restart = command;
            this.broker = broker;
        }

        public void present(IShell shell)
        {
        }

        public void notify(UnhandledErrorOccurred message)
        {
            view.display(message.error);
        }

        public void restart_application()
        {
            restart.run();
        }

        public void run()
        {
            broker.subscribe_to(this);
        }
    }
}