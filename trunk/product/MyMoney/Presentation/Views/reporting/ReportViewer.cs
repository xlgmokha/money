using DataDynamics.ActiveReports;
using MoMoney.Presentation.Model.reporting;
using MoMoney.Presentation.Views.core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Views.reporting
{
    public partial class ReportViewer : ApplicationDockedWindow, IReportViewer
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        public void display(IReport report)
        {
            var the_active_report = report.downcast_to<ActiveReport3>();
            the_active_report.Run();
            ux_report_viewer.Document = the_active_report.Document;
            titled(report.name);
        }
    }
}