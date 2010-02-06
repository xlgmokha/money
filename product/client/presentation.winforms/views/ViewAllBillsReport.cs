using System;
using System.Collections.Generic;
using DataDynamics.ActiveReports;
using gorilla.commons.utility;
using MoMoney.DTO;
using MoMoney.Presentation.Model.reporting;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class ViewAllBillsReport : ActiveReport, IViewAllBillsReport
    {
        public ViewAllBillsReport()
        {
            InitializeComponent();
            name = "View All Bills - Report";
        }

        public string name { get; private set; }

        public void run_against(IEnumerable<BillInformationDTO> bills)
        {
            ux_company_name.bind_to<BillInformationDTO, string>(x => x.company_name);
            ux_amount.bind_to<BillInformationDTO, string>(x => x.the_amount_owed);
            ux_due_date.bind_to<BillInformationDTO, DateTime>(x => x.due_date);
            DataSource = bills.databind();
        }
    }
}