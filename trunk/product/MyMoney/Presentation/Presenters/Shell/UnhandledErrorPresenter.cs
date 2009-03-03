using MyMoney.Infrastructure.eventing;
using MyMoney.Presentation.Core;
using MyMoney.Presentation.Model.messages;
using MyMoney.Presentation.Views.Shell;

namespace MyMoney.Presentation.Presenters.Shell
{
    public interface IUnhandledErrorPresenter : IPresenter, IEventSubscriber<unhandled_error_occurred>
    {
    }

    public class UnhandledErrorPresenter : IUnhandledErrorPresenter
    {
        readonly IUnhandledErrorView view;
        readonly IEventAggregator broker;

        public UnhandledErrorPresenter(IUnhandledErrorView view, IEventAggregator broker)
        {
            this.view = view;
            this.broker = broker;
        }

        public void run()
        {
            broker.subscribe_to(this);
        }

        public void notify(unhandled_error_occurred message)
        {
            view.display(message.error);
        }
    }
}