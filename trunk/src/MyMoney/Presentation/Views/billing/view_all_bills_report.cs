using System;
using System.Collections.Generic;
using DataDynamics.ActiveReports;
using MyMoney.Presentation.Model.reporting;
using MyMoney.Presentation.Presenters.billing.dto;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Views.billing
{
    public interface IViewAllBillsReport : IReport
    {
        void bind_to(IEnumerable<bill_information_dto> bills);
    }

    public partial class view_all_bills_report : ActiveReport3, IViewAllBillsReport
    {
        public view_all_bills_report()
        {
            InitializeComponent();
            name = "View All Bills - Report";
        }

        public string name { get; private set; }

        public void bind_to(IEnumerable<bill_information_dto> bills)
        {
            ux_company_name.bind_to<bill_information_dto, string>(x => x.company_name);
            ux_amount.bind_to<bill_information_dto, string>(x => x.the_amount_owed);
            ux_due_date.bind_to<bill_information_dto, DateTime>(x => x.due_date);
            DataSource = bills.databind();
        }
    }
}