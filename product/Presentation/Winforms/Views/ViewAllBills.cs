using System.Collections.Generic;
using System.Linq;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters.billing;
using MoMoney.Presentation.Views.billing;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class ViewAllBills : ApplicationDockedWindow, IViewAllBills
    {
        public ViewAllBills()
        {
            InitializeComponent();
            titled("View Bills");
        }

        public void attach_to(IViewAllBillsPresenter presenter)
        {
        }

        public void run(IEnumerable<BillInformationDTO> bills)
        {
            ux_bills.DataSource = bills.ToList();
        }
    }
}