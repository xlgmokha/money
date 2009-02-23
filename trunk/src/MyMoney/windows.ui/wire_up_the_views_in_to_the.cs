using MyMoney.Infrastructure.Container.Windsor;
using MyMoney.Presentation.Context;
using MyMoney.Presentation.Views;
using MyMoney.Presentation.Views.billing;
using MyMoney.Presentation.Views.income;
using MyMoney.Presentation.Views.Menu.Help;
using MyMoney.Presentation.Views.Navigation;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Presentation.Views.Startup;
using MyMoney.Utility.Core;

namespace MyMoney.windows.ui
{
    internal class wire_up_the_views_in_to_the : ICommand
    {
        private readonly windsor_dependency_registry registry;

        public wire_up_the_views_in_to_the(windsor_dependency_registry registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.register<IShell, window_shell>();
            registry.register<the_application_context, the_application_context>();
            registry.register_as_a_transient<IAboutApplicationView, about_the_application_view>();
            registry.register_as_a_transient<ISplashScreenView, splash_screen_view>();
            registry.register_as_a_transient<INavigationView, navigation_view>();
            registry.register_as_a_transient<IAddCompanyView, add_new_company_view>();
            registry.register_as_a_transient<IViewAllBills, view_all_bills>();
            registry.register_as_a_transient<IAddBillPaymentView, add_bill_payment>();
            registry.register_as_a_transient<IActionsTaskView, actions_task_list>();
            registry.register_as_a_transient<IAddNewIncomeView, add_new_income_view>();
            registry.register_as_a_transient<IViewIncomeHistory, view_all_income>();
        }
    }
}