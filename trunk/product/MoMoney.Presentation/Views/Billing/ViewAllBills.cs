using System.Collections.Generic;
using System.Linq;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.billing
{
    public partial class ViewAllBills : ApplicationDockedWindow, IViewAllBills
    {
        public ViewAllBills()
        {
            InitializeComponent();
            titled("View Bills");
        }

        public void display(IEnumerable<BillInformationDTO> bills)
        {
            ux_bills.DataSource = bills.ToList();
        }
    }
}