using System.Collections.Generic;
using System.Linq;
using MyMoney.Presentation.Presenters.billing.dto;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMoney.Presentation.Views.billing
{
    public partial class view_all_bills : DockContent, IViewAllBills
    {
        public view_all_bills()
        {
            InitializeComponent();
            TabText = "View Bills";
        }

        public void display(IEnumerable<bill_information_dto> bills)
        {
            ux_bills.DataSource = bills.ToList();
        }
    }
}