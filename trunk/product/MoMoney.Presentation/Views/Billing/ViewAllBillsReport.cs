using System;
using System.Collections.Generic;
using DataDynamics.ActiveReports;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.DTO;
using MoMoney.Presentation.Model.reporting;

namespace MoMoney.Presentation.Views.billing
{
    public interface IViewAllBillsReport : IReport
    {
        void run(IEnumerable<BillInformationDTO> bills);
    }

    public partial class ViewAllBillsReport : ActiveReport3, IViewAllBillsReport
    {
        public ViewAllBillsReport()
        {
            InitializeComponent();
            name = "View All Bills - Report";
        }

        public string name { get; private set; }

        public void run(IEnumerable<BillInformationDTO> bills)
        {
            ux_company_name.bind_to<BillInformationDTO, string>(x => x.company_name);
            ux_amount.bind_to<BillInformationDTO, string>(x => x.the_amount_owed);
            ux_due_date.bind_to<BillInformationDTO, DateTime>(x => x.due_date);
            DataSource = bills.databind();
        }
    }
}