using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Presenters.Shell;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Views.Core;
using MoMoney.Presentation.Winforms.Helpers;

namespace MoMoney.Presentation.Winforms.Views
{
    [Export(typeof (IShell))]
    public partial class ApplicationShell : ApplicationWindow, IShell
    {
        readonly IDictionary<string, IComponent> regions;
        ControlAction<EventArgs> closed_action;

        public ApplicationShell()
        {
            InitializeComponent();
            regions = new Dictionary<string, IComponent>
                          {
                              {GetType().FullName, this},
                              {typeof (Form).FullName, this},
                              {ux_main_menu_strip.GetType().FullName, ux_main_menu_strip},
                              {ux_dock_panel.GetType().FullName, ux_dock_panel},
                              {ux_tool_bar_strip.GetType().FullName, ux_tool_bar_strip},
                              {ux_status_bar.GetType().FullName, ux_status_bar},
                              {notification_icon.GetType().FullName, notification_icon},
                              {status_bar_label.GetType().FullName, status_bar_label},
                              {status_bar_progress_bar.GetType().FullName, status_bar_progress_bar}
                          };
            Closed += (o, e) => closed_action(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try_to_reduce_flickering();
        }

        public void attach_to(IApplicationShellPresenter presenter)
        {
            closed_action = x => presenter.shut_down();
        }

        public void add(IDockedContentView view)
        {
            view.add_to(ux_dock_panel);
        }

        public void region<Region>(Action<Region> action) where Region : IComponent
        {
            ensure_that_the_region_exists<Region>();
            action(regions[typeof (Region).FullName].downcast_to<Region>());
        }

        public void close_the_active_window()
        {
            ux_dock_panel.ActiveDocument.DockHandler.Close();
        }

        public void close_all_windows()
        {
            using (new SuspendLayout(ux_dock_panel))
                while (ux_dock_panel.Contents.Count > 0)
                {
                    ux_dock_panel.Contents[0].DockHandler.Close();
                }
        }

        void ensure_that_the_region_exists<T>()
        {
            if (!regions.ContainsKey(typeof (T).FullName))
                throw new Exception("Could not find region: {0}".formatted_using(typeof (T)));
        }
    }
}