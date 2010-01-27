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
            register.singleton<Shell>(() => shell);
            register.singleton<IWin32Window>(() => shell);
            register.singleton<ISynchronizeInvoke>(() => shell);
            register.singleton<IRegionManager>(() => shell);
            register.singleton(() => shell);
            register.singleton<IAboutApplicationView, AboutTheApplicationView>();
            register.singleton<ISplashScreenView, SplashScreenView>();
            register.singleton<INavigationView, NavigationView>();
            register.singleton<IAddCompanyView, AddCompanyView>();
            register.singleton<IViewAllBills, ViewAllBills>();
            register.singleton<IAddBillPaymentView, AddBillPaymentView>();
            register.singleton<IMainMenuView, MainMenuView>();
            register.singleton<IAddNewIncomeView, AddNewIncomeView>();
            register.singleton<IViewIncomeHistory, ViewAllIncome>();
            register.transient<ISaveChangesView, SaveChangesView>();
            register.transient<ICheckForUpdatesView, CheckForUpdatesView>();
            register.singleton<INotificationIconView, NotificationIconView>();
            register.singleton<IStatusBarView, StatusBarView>();
            register.transient<IUnhandledErrorView, UnhandledErrorView>();
            register.singleton<IGettingStartedView, WelcomeScreen>();
            register.singleton<ILogFileView, LogFileView>();
        }
    }
}