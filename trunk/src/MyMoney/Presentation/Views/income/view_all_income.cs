using System.Collections.Generic;
using System.Linq;
using MyMoney.Presentation.Presenters.income.dto;
using MyMoney.Utility.Extensions;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMoney.Presentation.Views.income
{
    public partial class view_all_income : DockContent, IViewIncomeHistory
    {
        public view_all_income()
        {
            InitializeComponent();
            TabText = "View All Income";
        }

        public void display(IEnumerable<income_information_dto> summary)
        {
            ux_view_all_income.DataSource = summary.databind();
        }
    }
}