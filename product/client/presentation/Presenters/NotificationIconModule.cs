using System.Net.NetworkInformation;
using MoMoney.Presentation;
using momoney.presentation.model.eventing;
using momoney.presentation.views;
using MoMoney.Presentation.Winforms.Resources;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public class NotificationIconModule : IModule,
                                          IEventSubscriber<ClosingTheApplication>,
                                          IEventSubscriber<NewProjectOpened>
    {
        readonly INotificationIconView view;

        public NotificationIconModule(INotificationIconView view)
        {
            this.view = view;
        }

        public void run()
        {
            NetworkChange.NetworkAvailabilityChanged += (o, e) => view.display(ApplicationIcons.Application, e.IsAvailable ? "Connected To A Network" : "Disconnected From Network");
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