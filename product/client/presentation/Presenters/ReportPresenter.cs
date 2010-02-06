using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.reporting;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Presenters
{
    public class ReportPresenter<Report, T, Query> : TabPresenter<IReportViewer>
        where Report : IBindReportTo<T, Query>
        where Query : Query<T>
    {
        readonly DependencyRegistry registry;

        public ReportPresenter(IReportViewer view, DependencyRegistry registry) : base(view)
        {
            this.registry = registry;
        }

        protected override void present()
        {
            var report = registry.get_a<Report>();
            report.run_against(registry.get_a<Query>().fetch());
            view.display(report);
        }
    }
}