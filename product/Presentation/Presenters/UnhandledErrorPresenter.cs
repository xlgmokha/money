using MoMoney.Presentation;
using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using momoney.presentation.views;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public interface IUnhandledErrorPresenter : IModule, IPresenter,
                                                IEventSubscriber<UnhandledErrorOccurred>
    {
        void restart_application();
    }

    public class UnhandledErrorPresenter : IUnhandledErrorPresenter
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

        public void present()
        {
            view.attach_to(this);
            broker.subscribe_to(this);
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
            present();
        }
    }
}