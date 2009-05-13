using System;
using DataDynamics.ActiveReports;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Model.reporting;
using MoMoney.Presentation.Views.core;

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