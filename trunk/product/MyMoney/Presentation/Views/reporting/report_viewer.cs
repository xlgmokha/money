using DataDynamics.ActiveReports;
using MyMoney.Presentation.Model.reporting;
using MyMoney.Presentation.Views.core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Views.reporting
{
    public partial class report_viewer : ApplicationDockedWindow, IReportView
    {
        public report_viewer()
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