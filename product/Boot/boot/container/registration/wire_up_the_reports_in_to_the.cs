using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Utility.Core;
using MoMoney.Presentation.Views.billing;
using MoMoney.Presentation.Views.reporting;
using MoMoney.Presentation.Winforms.Views;

namespace MoMoney.boot.container.registration
{
    class wire_up_the_reports_in_to_the : ICommand
    {
        readonly IDependencyRegistration registry;

        public wire_up_the_reports_in_to_the(IDependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.transient<IReportViewer, ReportViewer>();
            registry.transient<IViewAllBillsReport, ViewAllBillsReport>();
        }
    }
}