using DataDynamics.ActiveReports;
using MyMoney.Presentation.Model.reporting;
using MyMoney.Utility.Extensions;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMoney.Presentation.Views.reporting
{
    public partial class report_viewer : DockContent, IReportView
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
            TabText = report.name;
        }
    }
}