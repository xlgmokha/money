using System.Collections.Generic;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.income
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