using System.Collections.Generic;
using MyMoney.Presentation.Presenters.income.dto;
using MyMoney.Presentation.Views.core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Views.income
{
    public partial class view_all_income : ApplicationDockedWindow, IViewIncomeHistory
    {
        public view_all_income()
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