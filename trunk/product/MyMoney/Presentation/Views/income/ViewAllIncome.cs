using System.Collections.Generic;
using Castle.Core;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Presentation.Views.core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Views.income
{
    [Interceptor(typeof (ISynchronizedInterceptor))]
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