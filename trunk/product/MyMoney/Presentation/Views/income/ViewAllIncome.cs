using System.Collections.Generic;
using MyMoney.Presentation.Presenters.income.dto;
using MyMoney.Presentation.Views.core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Views.income
{
    public partial class ViewAllIncome : ApplicationDockedWindow, IViewIncomeHistory
    {
        public ViewAllIncome()
        {
            InitializeComponent();
            titled("View All Income");
        }

        public void display(IEnumerable<income_information_dto> summary)
        {
            ux_view_all_income.DataSource = summary.databind();
        }
    }
}