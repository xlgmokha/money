using MoMoney.Infrastructure.Container;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Views.billing;
using MoMoney.Presentation.Views.dialogs;
using MoMoney.Presentation.Views.income;
using MoMoney.Presentation.Views.Menu.Help;
using MoMoney.Presentation.Views.Navigation;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Presentation.Views.Startup;
using MoMoney.Presentation.Views.updates;
using MoMoney.Utility.Core;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_views_in_to_the : ICommand
    {
        readonly IDependencyRegistration register;

        public wire_up_the_views_in_to_the(IDependencyRegistration registry)
        {
            register = registry;
        }

        public void run()
        {
            var shell = new ApplicationShell();
            register.singleton<IShell>(() => shell);
            //register.proxy<IShell, SynchronizedConfiguration<IShell>>(() => shell);
            register.singleton(() => shell);
            register.transient<IAboutApplicationView, AboutTheApplicationView>();
            register.transient<ISplashScreenView, SplashScreenView>();
            register.transient<INavigationView, NavigationView>();
            register.transient<IAddCompanyView, AddCompanyView>();
            register.transient<IViewAllBills, ViewAllBills>();
            register.transient<IAddBillPaymentView, add_bill_payment>();
            register.transient<IMainMenuView, MainMenuView>();
            register.transient<IAddNewIncomeView, AddNewIncomeView>();
            register.transient<IViewIncomeHistory, ViewAllIncome>();
            register.transient<ISaveChangesView, SaveChangesView>();
            register.transient<ICheckForUpdatesView, CheckForUpdatesView>();
            register.singleton<INotificationIconView, NotificationIconView>();
            register.transient<IStatusBarView, StatusBarView>();
            register.transient<IUnhandledErrorView, UnhandledErrorView>();
            register.transient<IGettingStartedView, WelcomeScreen>();
            register.transient<ILogFileView, LogFileView>();
        }
    }
}