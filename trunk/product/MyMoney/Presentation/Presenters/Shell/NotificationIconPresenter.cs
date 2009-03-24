using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface INotificationIconPresenter : IPresentationModule,
                                                  IEventSubscriber<ClosingTheApplication>,
                                                  IEventSubscriber<NewProjectOpened>
    {
    }

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
            broker.subscribe_to<ClosingTheApplication>(this);
            broker.subscribe_to<NewProjectOpened>(this);
            view.display(ApplicationIcons.Application, "mokhan.ca");
        }

        public void notify(ClosingTheApplication message)
        {
            view.Dispose();
        }

        public void notify(NewProjectOpened message)
        {
            view.opened_new_project();
        }
    }
}