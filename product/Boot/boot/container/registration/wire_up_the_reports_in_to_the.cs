using System.Collections.Generic;
using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.utility;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Views;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.boot.container.registration
{
    class wire_up_the_reports_in_to_the : Command
    {
        readonly DependencyRegistration registry;

        public wire_up_the_reports_in_to_the(DependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.transient<IReportViewer, ReportViewer>();
            registry.transient(typeof (IPresenter), typeof (ReportPresenter<IViewAllBillsReport, IEnumerable<BillInformationDTO>, IGetAllBillsQuery>));
            registry.transient<IViewAllBillsReport, ViewAllBillsReport>();
            registry.transient(typeof (IPresenter), typeof (ReportPresenter<IViewAllIncomeReport, IEnumerable<IncomeInformationDTO>, IGetAllIncomeQuery>));
            registry.transient<IViewAllIncomeReport, ViewAllIncomeReport>();
        }
    }
}