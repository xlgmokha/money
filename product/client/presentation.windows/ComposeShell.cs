using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using presentation.windows.presenters;
using presentation.windows.views;

namespace presentation.windows
{
    public class ComposeShell : NeedStartup
    {
        RegionManager region_manager;
        ApplicationController controller;

        public ComposeShell(RegionManager region_manager, ApplicationController controller)
        {
            this.region_manager = region_manager;
            this.controller = controller;
        }

        public void run()
        {
            controller.add_tab<CompensationPresenter, CompensationTab>();
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "Expenses"}));
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "RRSP"}));
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "Party"}));
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "Assets"}));
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "Liabilities"}));
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "Budget"}));

            region_manager.region<StatusBar>(x => x.Items.Add(new Label {Content = Thread.CurrentPrincipal.Identity.Name}));
            region_manager.region<StatusBar>(x => x.Items.Add(new Label {Content = "Software Developer"}));

            region_manager.region<MainMenu>(x =>
            {
                x.add("_File").add("E_xit", () =>
                {
                    Application.Current.Shutdown();
                });
                x.add("F_amily").add("_Add Member", () =>
                {
                    controller.launch_dialog<AddFamilyMemberPresenter, AddFamilyMemberDialog>();
                    MessageBox.Show("Add Family");
                });
            });
        }
    }
}