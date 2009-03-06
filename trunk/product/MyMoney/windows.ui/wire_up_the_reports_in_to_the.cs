using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Presentation.Views.billing;
using MoMoney.Presentation.Views.reporting;
using MoMoney.Utility.Core;

namespace MoMoney.windows.ui
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
            registry.transient<IReportViewer, ReportViewer>();
            registry.transient<IViewAllBillsReport, view_all_bills_report>();
        }
    }
}