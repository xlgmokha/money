using System.Windows.Forms;
using Castle.Core;
using MyMoney.Presentation.Model.Menu;
using MyMoney.Presentation.Model.Menu.File;
using MyMoney.Presentation.Model.Menu.Help;
using MyMoney.Presentation.Model.Menu.window;
using MyMoney.Presentation.Resources;

namespace MyMoney.Presentation.Views.Shell
{
    [Singleton]
    public class NotificationIconView : INotificationIconView
    {
        NotifyIcon ux_notification_icon;
        readonly IFileMenu file_menu;
        readonly IWindowMenu window_menu;
        readonly IHelpMenu help_menu;
        bool hooked_up;

        public NotificationIconView(IFileMenu file_menu, IWindowMenu window_menu, IHelpMenu help_menu)
        {
            this.file_menu = file_menu;
            this.window_menu = window_menu;
            this.help_menu = help_menu;
            Application.ApplicationExit += (sender, e) => Dispose();
        }

        public void display(ApplicationIcon icon_to_display, string text_to_display)
        {
            if (hooked_up)
            {
                return;
            }
            ux_notification_icon =
                new NotifyIcon
                    {
                        BalloonTipIcon = ToolTipIcon.Info,
                        BalloonTipText = "Thanks for trying out this sample application",
                        Icon = icon_to_display,
                        Text = text_to_display,
                        Visible = true,
                        ContextMenu = new ContextMenu
                                          {
                                              MenuItems =
                                                  {
                                                      map_from(file_menu),
                                                      map_from(window_menu),
                                                      map_from(help_menu)
                                                  }
                                          }
                    };
            hooked_up = true;
        }

        public void opened_new_project()
        {
            ux_notification_icon.ShowBalloonTip(100, "If you need any help check out mokhan.ca", "", ToolTipIcon.Info);
        }

        public void show_popup_message(string message)
        {
            ux_notification_icon.ShowBalloonTip(100, message, message, ToolTipIcon.Info);
        }

        MenuItem map_from(ISubMenu item)
        {
            var toolStripMenuItem = new MenuItem(item.name);
            foreach (var menuItem in item.all_menu_items())
            {
                toolStripMenuItem.MenuItems.Add(menuItem.build_menu_item());
            }
            return toolStripMenuItem;
        }

        public void Dispose()
        {
            if (ux_notification_icon != null)
            {
                ux_notification_icon.Visible = false;
                ux_notification_icon.Dispose();
                ux_notification_icon = null;
            }
        }
    }
}