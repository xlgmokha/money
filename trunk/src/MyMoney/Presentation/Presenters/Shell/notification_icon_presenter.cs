using Castle.Core;
using MyMoney.Infrastructure.eventing;
using MyMoney.Presentation.Model.messages;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.Shell;

namespace MyMoney.Presentation.Presenters.Shell
{
    public interface INotificationIconPresenter : IPresentationModule, IEventSubscriber<closing_the_application>
    {
    }

    [Singleton]
    public class notification_icon_presenter : INotificationIconPresenter
    {
        readonly INotificationIconView view;
        readonly IEventAggregator broker;

        public notification_icon_presenter(INotificationIconView view, IEventAggregator broker)
        {
            this.view = view;
            this.broker = broker;
        }

        public void run()
        {
            broker.subscribe_to(this);
            view.display(ApplicationIcons.Application, "mokhan.ca");
        }

        public void notify(closing_the_application message)
        {
            view.Dispose();
        }
    }
}