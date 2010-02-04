using System;
using System.Windows.Forms;
using gorilla.commons.utility;
using MoMoney.Presentation.Model.Menu;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Menu.Help;
using MoMoney.Presentation.Model.Menu.window;
using momoney.presentation.presenters;
using momoney.presentation.resources;
using momoney.presentation.views;
using MenuItem = System.Windows.Forms.MenuItem;

namespace MoMoney.Presentation.Winforms.Views
{
    public class NotificationIconView : INotificationIconView
    {
        IFileMenu file_menu;
        IWindowMenu window_menu;
        IHelpMenu help_menu;
        IRegionManager shell;

        public NotificationIconView()
        {
            Application.ApplicationExit += (sender, e) => Dispose();
        }

        public void attach_to(NotificationIconPresenter presenter)
        {
            this.shell = presenter.shell;
            this.file_menu = presenter.file_menu;
            this.window_menu = presenter.window_menu;
            this.help_menu = presenter.help_menu;
        }

        public void display(ApplicationIcon icon_to_display, string text_to_display)
        {
            shell.region<NotifyIcon>(x =>
            {
                x.Icon = icon_to_display;
                x.Text = text_to_display;
                x.ContextMenu = new ContextMenu
                                {
                                    MenuItems =
                                        {
                                            map_from(file_menu),
                                            map_from(window_menu),
                                            map_from(help_menu)
                                        }
                                };
            });
        }

        public void opened_new_project()
        {
            show_popup_message("If you need any help check out mokhan.ca");
        }

        public void show_popup_message(string message)
        {
            shell.region<NotifyIcon>(x => x.ShowBalloonTip(100, message, message, ToolTipIcon.Info));
        }

        MenuItem map_from(ISubMenu item)
        {
            var menu_item = new MenuItem(item.name);
            item.all_menu_items().each(x => menu_item.MenuItems.Add(x.build_menu_item()));
            return menu_item;
        }

        public void Dispose()
        {
            shell.region<NotifyIcon>(x =>
            {
                if (x != null)
                {
                    x.Visible = false;
                    x.Dispose();
                }
            });
        }

        public IAsyncResult BeginInvoke(Delegate method, object[] args)
        {
            throw new NotImplementedException();
        }

        public object EndInvoke(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public object Invoke(Delegate method, object[] args)
        {
            throw new NotImplementedException();
        }

        public bool InvokeRequired
        {
            get { throw new NotImplementedException(); }
        }
    }
}