using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using MoMoney.Presentation.Views.core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Views.Shell
{
    [Export(typeof (IShell))]
    public partial class ApplicationShell : ApplicationWindow, IShell
    {
        readonly IDictionary<string, Control> regions;

        public ApplicationShell()
        {
            InitializeComponent();
            regions = new Dictionary<string, Control>
                          {
                              {ux_main_menu_strip.GetType().FullName, ux_main_menu_strip},
                              {ux_dock_panel.GetType().FullName, ux_dock_panel},
                              {ux_tool_bar_strip.GetType().FullName, ux_tool_bar_strip},
                              {ux_status_bar.GetType().FullName, ux_status_bar}
                          };
        }

        public void add(IDockedContentView view)
        {
            on_ui_thread(() => view.add_to(ux_dock_panel));
        }

        public void region<T>(Action<T> action) where T : Control
        {
            on_ui_thread(() => action(regions[typeof (T).FullName].downcast_to<T>()));
        }

        public void close_the_active_window()
        {
            on_ui_thread(() => ux_dock_panel.ActiveDocument.DockHandler.Close());
        }

        public void close_all_windows()
        {
            on_ui_thread(() =>
                             {
                                 while (ux_dock_panel.Contents.Count > 0)
                                 {
                                     ux_dock_panel.Contents[0].DockHandler.Close();
                                 }
                             });
        }

        //public void clear_menu_items()
        //{
        //    on_ui_thread(() =>
        //                     {
        //                         ux_tool_bar_strip.Items.Clear();
        //                         ux_main_menu_strip.Items.Clear();
        //                     });
        //}
    }
}