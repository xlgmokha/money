using System.Collections.Generic;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters.income;
using MoMoney.Presentation.Views.income;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class ViewAllIncome : ApplicationDockedWindow, IViewIncomeHistory
    {
        public ViewAllIncome()
        {
            InitializeComponent();
            titled("View All Income");
        }

        public void attach_to(IViewIncomeHistoryPresenter presenter)
        {
        }

        public void run(IEnumerable<IncomeInformationDTO> summary)
        {
            ux_view_all_income.DataSource = summary.databind();
        }
    }
}