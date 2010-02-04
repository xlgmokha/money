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
            register_singleton<ITitleBar, TitleBar>();
            register_singleton<ITaskTrayMessageView, TaskTrayMessage>();

            register_transient<ISelectFileToOpenDialog, SelectFileToOpenDialog>();
            register_transient<ISelectFileToSaveToDialog, SelectFileToSaveToDialog>();
            register_transient<ISaveChangesView, SaveChangesView>();
            register_transient<ICheckForUpdatesView, CheckForUpdatesView>();
            register_transient<IUnhandledErrorView, UnhandledErrorView>();
        }

        void register_singleton<Interface, View>() where View : Interface, new() where Interface : momoney.presentation.views.View
        {
            var view = new View();
            register.singleton<Interface>(() => view);
            register.singleton<momoney.presentation.views.View>(() => view);
        }

        void register_transient<Interface, View>() where View : Interface, new() where Interface : momoney.presentation.views.View
        {
            var view = new View();
            register.singleton<Interface>(() => view);
            register.singleton<momoney.presentation.views.View>(() => view);
            //register.transient<Interface,View>();
            //register.transient<momoney.presentation.views.View>(() => Resolve.the<Interface>());
        }
    }
}