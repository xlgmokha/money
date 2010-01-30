using System.ComponentModel;
using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Reflection;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.utility;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Views;
using View = momoney.presentation.views.View;

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
            register.singleton<IAboutApplicationView, AboutTheApplicationView>();
            register.singleton<ISplashScreenView, SplashScreenView>();
            register.singleton<INavigationView, NavigationView>();
            register.singleton<IAddCompanyView, AddCompanyView>();
            register.singleton<IViewAllBills, ViewAllBills>();
            register.singleton<IAddBillPaymentView, AddBillPaymentView>();
            register.singleton<IMainMenuView, MainMenuView>();
            register.singleton<IAddNewIncomeView, AddNewIncomeView>();
            register.singleton<IViewIncomeHistory, ViewAllIncome>();
            register.singleton<INotificationIconView, NotificationIconView>();
            register.singleton<IStatusBarView, StatusBarView>();
            register.singleton<IGettingStartedView, WelcomeScreen>();
            register.singleton<ILogFileView, LogFileView>();

            register.transient<ISaveChangesView, SaveChangesView>();
            register.transient<ICheckForUpdatesView, CheckForUpdatesView>();
            register.transient<IUnhandledErrorView, UnhandledErrorView>();


            item.all_classes_that_implement<View>().each(x =>
            {
                register.singleton(typeof (View), x);
            });
        }
    }
}