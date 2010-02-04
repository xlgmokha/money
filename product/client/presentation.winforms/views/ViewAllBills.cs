using System.Collections.Generic;
using System.Linq;
using MoMoney.DTO;
using momoney.presentation.presenters;
using momoney.presentation.resources;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class ViewAllBills : ApplicationDockedWindow, IViewAllBills
    {
        public ViewAllBills()
        {
            InitializeComponent();
            titled("View Bill Payments").icon(ApplicationIcons.ViewAllBillPayments);
        }

        public void attach_to(ViewAllBillsPresenter presenter)
        {
        }

        public void run(IEnumerable<BillInformationDTO> bills)
        {
            ux_bills.DataSource = bills.ToList();
        }
    }
}