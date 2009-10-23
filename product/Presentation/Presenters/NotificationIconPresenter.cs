using System.Net.NetworkInformation;
using MoMoney.Presentation;
using momoney.presentation.model.eventing;
using momoney.presentation.views;
using MoMoney.Presentation.Winforms.Resources;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public interface INotificationIconPresenter : IModule,
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
            NetworkChange.NetworkAvailabilityChanged += (sender, args) => view.display(ApplicationIcons.Application, args.IsAvailable ? "Connected To A Network" : "Disconnected From Network");
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