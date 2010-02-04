using System.Net.NetworkInformation;
using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Menu.Help;
using MoMoney.Presentation.Model.Menu.window;
using momoney.presentation.resources;
using momoney.presentation.views;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public class NotificationIconPresenter : Presenter,
                                             EventSubscriber<ClosingTheApplication>,
                                             EventSubscriber<NewProjectOpened>
    {
        readonly INotificationIconView view;

        public NotificationIconPresenter(INotificationIconView view, IFileMenu file, IWindowMenu window, IHelpMenu help)
        {
            this.view = view;
            file_menu = file;
            window_menu = window;
            help_menu = help;
        }

        public IRegionManager shell { get; set; }
        public IFileMenu file_menu { get; set; }
        public IWindowMenu window_menu { get; set; }
        public IHelpMenu help_menu { get; set; }

        public void present(Shell shell)
        {
            this.shell = shell;
            view.attach_to(this);
            view.display(ApplicationIcons.Application, "mokhan.ca");
            NetworkChange.NetworkAvailabilityChanged += (o, e) => view.display(ApplicationIcons.Application, e.IsAvailable ? "Connected To A Network" : "Disconnected From Network");
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