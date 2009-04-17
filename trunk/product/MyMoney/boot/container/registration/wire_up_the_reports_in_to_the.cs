using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.Container;
using MoMoney.Presentation.Views.billing;
using MoMoney.Presentation.Views.reporting;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_reports_in_to_the : ICommand
    {
        private readonly IDependencyRegistration registry;

        public wire_up_the_reports_in_to_the(IDependencyRegistration registry)
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