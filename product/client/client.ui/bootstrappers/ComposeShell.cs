using System.Windows.Controls;
using presentation.windows.common;
using presentation.windows.presenters;
using presentation.windows.views;

namespace presentation.windows.bootstrappers
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
            controller.add_tab<AccountPresenter, AccountTab>();
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "Expenses"}));
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "RRSP"}));
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "Party"}));
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "Assets"}));
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "Liabilities"}));
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem {Header = "Budget"}));

            region_manager.region<MainMenu>(x =>
            {
                x.add("_Family").add("_Add Member", () =>
                {
                    controller.launch_dialog<AddFamilyMemberPresenter, AddFamilyMemberDialog>();
                });
            });

            controller.load_region<StatusBarPresenter, StatusBarRegion>();
            controller.load_region<SelectedFamilyMemberPresenter, SelectedFamilyMemberRegion>();
        }
    }
}