using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Views.reporting;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Presentation.Presenters
{
    public interface IReportPresenter : IContentPresenter
    {
    }

    public class ReportPresenter : ContentPresenter<IReportViewer>, IReportPresenter
    {
        readonly IViewAllBillsReport report;
        readonly IGetAllBillsQuery query;

        public ReportPresenter(IReportViewer view, IViewAllBillsReport report, IGetAllBillsQuery query) : base(view)
        {
            this.report = report;
            this.query = query;
        }

        public override void run()
        {
            report.run(query.fetch());
            view.display(report);
        }
    }
}