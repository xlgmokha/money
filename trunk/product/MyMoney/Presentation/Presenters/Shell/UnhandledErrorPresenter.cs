using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IUnhandledErrorPresenter : IPresentationModule, IPresenter,
                                                IEventSubscriber<unhandled_error_occurred>
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

        public void run()
        {
            view.attach_to(this);
            broker.subscribe_to(this);
        }

        public void notify(unhandled_error_occurred message)
        {
            view.display(message.error);
        }

        public void restart_application()
        {
            restart.run();
        }
    }
}