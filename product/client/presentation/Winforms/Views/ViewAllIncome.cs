using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class ViewAllIncome : ApplicationDockedWindow, IViewIncomeHistory
    {
        public ViewAllIncome()
        {
            InitializeComponent();
            titled("View All Income").icon(ApplicationIcons.ViewAllIncome);
        }

        public void attach_to(ViewIncomeHistoryPresenter presenter) {}

        public void run(IEnumerable<IncomeInformationDTO> summary)
        {
            ux_view_all_income.DataSource = summary.databind();
        }
    }
}