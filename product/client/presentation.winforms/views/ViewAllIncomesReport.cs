using System.Collections.Generic;
using DataDynamics.ActiveReports;
using gorilla.commons.utility;
using MoMoney.DTO;
using MoMoney.Presentation.Model.reporting;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class ViewAllIncomeReport : ActiveReport, IViewAllIncomeReport
    {
        public ViewAllIncomeReport()
        {
            InitializeComponent();
            name = "View All Income - Report";
        }

        public string name { get; private set; }

        public void run_against(IEnumerable<IncomeInformationDTO> income)
        {
            ux_company_name.bind_to<IncomeInformationDTO, string>(x => x.company);
            ux_amount.bind_to<IncomeInformationDTO, string>(x => x.amount);
            ux_received_date.bind_to<IncomeInformationDTO, string>(x => x.recieved_date);
            DataSource = income.databind();
        }
    }
}