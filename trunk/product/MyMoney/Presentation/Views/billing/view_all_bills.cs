using System.Collections.Generic;
using System.Linq;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.billing
{
    public partial class view_all_bills : ApplicationDockedWindow, IViewAllBills
    {
        public view_all_bills()
        {
            InitializeComponent();
            titled("View Bills");
        }

        public void display(IEnumerable<bill_information_dto> bills)
        {
            ux_bills.DataSource = bills.ToList();
        }
    }
}