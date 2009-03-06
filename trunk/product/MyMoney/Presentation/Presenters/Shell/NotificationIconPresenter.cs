using Castle.Core;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface INotificationIconPresenter : IPresentationModule,
                                                  IEventSubscriber<closing_the_application>,
                                                  IEventSubscriber<new_project_opened>
    {
    }

    [Singleton]
    public class NotificationIconPresenter : INotificationIconPresenter
    {
        readonly INotificationIconView view;
        readonly IEventAggregator broker;

        public NotificationIconPresenter(INotificationIconView view, IEventAggregator broker)
        {
            this.view = view;
            this.broker = broker;
        }

        public void run()
        {
            broker.subscribe_to<closing_the_application>(this);
            broker.subscribe_to<new_project_opened>(this);
            view.display(ApplicationIcons.Application, "mokhan.ca");
        }

        public void notify(closing_the_application message)
        {
            view.Dispose();
        }

        public void notify(new_project_opened message)
        {
            view.opened_new_project();
        }
    }
}