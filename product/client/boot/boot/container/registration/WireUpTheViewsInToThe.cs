using System.ComponentModel;
using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Reflection;
using gorilla.commons.infrastructure.thirdparty;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Views;

namespace MoMoney.boot.container.registration
{
    class WireUpTheViewsInToThe : IStartupCommand
    {
        readonly DependencyRegistration register;

        public WireUpTheViewsInToThe(DependencyRegistration registry)
        {
            register = registry;
        }

        public void run(Assembly item)
        {
            var shell = new ApplicationShell();
            register.singleton<Shell>(() => shell);
            register.singleton<IWin32Window>(() => shell);
            register.singleton<ISynchronizeInvoke>(() => shell);
            register.singleton<IRegionManager>(() => shell);
            register.singleton(() => shell);
            register_tab<IAboutApplicationView, AboutTheApplicationView>();
            register_tab<ISplashScreenView, SplashScreenView>();
            register_tab<IAddCompanyView, AddCompanyView>();
            register_tab<IViewAllBills, ViewAllBills>();
            register_tab<IAddBillPaymentView, AddBillPaymentView>();
            register_tab<IMainMenuView, MainMenuView>();
            register_tab<IAddNewIncomeView, AddNewIncomeView>();
            register_tab<IViewIncomeHistory, ViewAllIncome>();
            register_tab<INotificationIconView, NotificationIconView>();
            register_tab<IStatusBarView, StatusBarView>();
            register_tab<IGettingStartedView, WelcomeScreen>();
            register_tab<ILogFileView, LogFileView>();

            register.transient<ISaveChangesView, SaveChangesView>();
            register.transient<ICheckForUpdatesView, CheckForUpdatesView>();
            register.transient<IUnhandledErrorView, UnhandledErrorView>();
        }

        void register_tab<Interface, View>() where View : Interface, new() where Interface : momoney.presentation.views.View
        {
            var view = new View();
            register.singleton<Interface>(() => view);
            register.singleton<momoney.presentation.views.View>(() => view);
        }
    }
}