using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IUnhandledErrorPresenter : IPresentationModule, IPresenter, IEventSubscriber<unhandled_error_occurred>
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
            this.log().debug("received error");
            view.display(message.error);
        }
    }
}