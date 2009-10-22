using System.ComponentModel;
using System.Windows.Forms;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.utility;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Views;

namespace MoMoney.boot.container.registration
{
    class wire_up_the_views_in_to_the : Command
    {
        readonly DependencyRegistration register;

        public wire_up_the_views_in_to_the(DependencyRegistration registry)
        {
            register = registry;
        }

        public void run()
        {
            var shell = new ApplicationShell();
            register.singleton<IShell>(() => shell);
            register.singleton<IWin32Window>(() => shell);
            register.singleton<ISynchronizeInvoke>(() => shell);
            register.singleton<IRegionManager>(() => shell);
            //register.proxy<IShell, SynchronizedConfiguration<IShell>>(() => shell);
            register.singleton(() => shell);
            register.transient<IAboutApplicationView, AboutTheApplicationView>();
            register.transient<ISplashScreenView, SplashScreenView>();
            register.transient<INavigationView, NavigationView>();
            register.transient<IAddCompanyView, AddCompanyView>();
            register.transient<IViewAllBills, ViewAllBills>();
            register.transient<IAddBillPaymentView, AddBillPaymentView>();
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