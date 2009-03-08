using System.Windows.Forms;
using Castle.Core;
using MoMoney.Presentation.Model.Menu;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Menu.Help;
using MoMoney.Presentation.Model.Menu.window;
using MoMoney.Presentation.Resources;
using MoMoney.Utility.Extensions;
using MenuItem=System.Windows.Forms.MenuItem;

namespace MoMoney.Presentation.Views.Shell
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
            show_popup_message("If you need any help check out mokhan.ca");
        }

        public void show_popup_message(string message)
        {
            ux_notification_icon.ShowBalloonTip(100, message, message, ToolTipIcon.Info);
        }

        MenuItem map_from(ISubMenu item)
        {
            var menu_item = new MenuItem(item.name);
            item.all_menu_items().each(x => menu_item.MenuItems.Add(x.build_menu_item()) );
            return menu_item;
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