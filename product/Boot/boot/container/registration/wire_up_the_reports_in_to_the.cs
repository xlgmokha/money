using System.Collections.Generic;
using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Utility.Core;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Views;
using MoMoney.Service.Contracts.Application;

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
            registry.transient(typeof (IPresenter), typeof (ReportPresenter<IViewAllBillsReport,IEnumerable<BillInformationDTO>,IGetAllBillsQuery>));
            registry.transient<IViewAllBillsReport, ViewAllBillsReport>();
            registry.transient(typeof (IPresenter), typeof (ReportPresenter<IViewAllIncomeReport,IEnumerable<IncomeInformationDTO>,IGetAllIncomeQuery>));
            registry.transient<IViewAllIncomeReport, ViewAllIncomeReport>();
        }
    }
}