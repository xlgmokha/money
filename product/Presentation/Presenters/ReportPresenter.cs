using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Core;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.reporting;
using MoMoney.Presentation.Views.reporting;

namespace MoMoney.Presentation.Presenters
{
    public interface IReportPresenter<Report, T, Query> : IContentPresenter
        where Report : IBindReportTo<T, Query>
        where Query : IQuery<T>
    {
    }

    public class ReportPresenter<Report, T, Query> : ContentPresenter<IReportViewer>, IReportPresenter<Report, T, Query>
        where Report : IBindReportTo<T, Query>
        where Query : IQuery<T>
    {
        readonly IDependencyRegistry registry;

        public ReportPresenter(IReportViewer view, IDependencyRegistry registry) : base(view)
        {
            this.registry = registry;
        }

        public override void run()
        {
            var report = registry.get_a<Report>();
            report.run(registry.get_a<Query>().fetch());
            view.display(report);
        }
    }
}