using System.Collections.Generic;
using Gorilla.Commons.Infrastructure.Reflection;
using gorilla.commons.infrastructure.thirdparty;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Views;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.boot.container.registration
{
    class WireUpTheReportsInToThe : IStartupCommand
    {
        readonly DependencyRegistration registry;

        public WireUpTheReportsInToThe(DependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run_against(Assembly item)
        {
            registry.singleton<IReportViewer, ReportViewer>();
            registry.transient(typeof (Presenter), typeof (ReportPresenter<IViewAllBillsReport, IEnumerable<BillInformationDTO>, IGetAllBillsQuery>));
            registry.singleton<IViewAllBillsReport, ViewAllBillsReport>();
            registry.transient(typeof (Presenter), typeof (ReportPresenter<IViewAllIncomeReport, IEnumerable<IncomeInformationDTO>, IGetAllIncomeQuery>));
            registry.singleton<IViewAllIncomeReport, ViewAllIncomeReport>();
        }
    }
}