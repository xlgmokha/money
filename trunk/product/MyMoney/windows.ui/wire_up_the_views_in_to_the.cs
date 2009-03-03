using MyMoney.Infrastructure.Container.Windsor;
using MyMoney.Presentation.Context;
using MyMoney.Presentation.Views;
using MyMoney.Presentation.Views.billing;
using MyMoney.Presentation.Views.dialogs;
using MyMoney.Presentation.Views.income;
using MyMoney.Presentation.Views.Menu.Help;
using MyMoney.Presentation.Views.Navigation;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Presentation.Views.Startup;
using MyMoney.Presentation.Views.updates;
using MyMoney.Utility.Core;

namespace MyMoney.windows.ui
{
    internal class wire_up_the_views_in_to_the : ICommand
    {
        readonly windsor_dependency_registry register;

        public wire_up_the_views_in_to_the(windsor_dependency_registry registry)
        {
            register = registry;
        }

        public void run()
        {
            register.singleton<IShell, ApplicationShell>();
            register.singleton<the_application_context, the_application_context>();
            register.transient<IAboutApplicationView, about_the_application_view>();
            register.transient<ISplashScreenView, splash_screen_view>();
            register.transient<INavigationView, navigation_view>();
            register.transient<IAddCompanyView, add_new_company_view>();
            register.transient<IViewAllBills, view_all_bills>();
            register.transient<IAddBillPaymentView, add_bill_payment>();
            register.transient<IMainMenuView, MainMenuView>();
            register.transient<IAddNewIncomeView, AddNewIncomeView>();
            register.transient<IViewIncomeHistory, ViewAllIncome>();
            register.transient<ISaveChangesView, SaveChangesView>();
            register.transient<ICheckForUpdatesView, CheckForUpdatesView>();
            register.transient<INotificationIconView, NotificationIconView>();
            register.transient<IStatusBarView, StatusBarView>();
        }
    }
}