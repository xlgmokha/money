using System.Collections.Generic;
using System.Linq;
using MyMoney.Presentation.Presenters.billing.dto;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.billing
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