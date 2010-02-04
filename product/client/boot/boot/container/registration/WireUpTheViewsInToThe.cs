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
            register_singleton<IAboutApplicationView, AboutTheApplicationView>();
            register_singleton<ISplashScreenView, SplashScreenView>();
            register_singleton<IAddCompanyView, AddCompanyView>();
            register_singleton<IViewAllBills, ViewAllBills>();
            register_singleton<IAddBillPaymentView, AddBillPaymentView>();
            register_singleton<IMainMenuView, MainMenuView>();
            register_singleton<IAddNewIncomeView, AddNewIncomeView>();
            register_singleton<IViewIncomeHistory, ViewAllIncome>();
            register_singleton<INotificationIconView, NotificationIconView>();
            register_singleton<IStatusBarView, StatusBarView>();
            register_singleton<IGettingStartedView, WelcomeScreen>();
            register_singleton<ILogFileView, LogFileView>();
            register.singleton<ITitleBar, TitleBar>();
            register.singleton<ITaskTrayMessageView, TaskTrayMessage>();

            register_singleton<ISelectFileToOpenDialog, SelectFileToOpenDialog>();
            register_singleton<ISelectFileToSaveToDialog, SelectFileToSaveToDialog>();
            register_singleton<ISaveChangesView, SaveChangesView>();
            register_singleton<ICheckForUpdatesView, CheckForUpdatesView>();
            register_singleton<IUnhandledErrorView, UnhandledErrorView>();
        }

        void register_singleton<Interface, View>() where View : Interface, new() where Interface : momoney.presentation.views.View
        {
            var view = new View();
            register.singleton<Interface>(() => view);
            register.singleton<momoney.presentation.views.View>(() => view);
        }
    }
}