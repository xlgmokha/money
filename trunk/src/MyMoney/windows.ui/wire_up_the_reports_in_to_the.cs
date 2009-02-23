using MyMoney.Infrastructure.Container.Windsor;
using MyMoney.Presentation.Views.billing;
using MyMoney.Presentation.Views.reporting;
using MyMoney.Utility.Core;

namespace MyMoney.windows.ui
{
    internal class wire_up_the_reports_in_to_the : ICommand
    {
        private readonly windsor_dependency_registry registry;

        public wire_up_the_reports_in_to_the(windsor_dependency_registry registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.register_as_a_transient<IReportView, report_viewer>();
            registry.register_as_a_transient<IViewAllBillsReport, view_all_bills_report>();
        }
    }
}