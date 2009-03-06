using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Presenters.billing;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Views.billing
{
    public partial class add_bill_payment : ApplicationDockedWindow, IAddBillPaymentView
    {
        public add_bill_payment()
        {
            InitializeComponent();
            titled("Add Bill Payment");
        }

        public void attach_to(IAddBillPaymentPresenter presenter)
        {
            ux_submit_button.Click += (sender, e) => presenter.submit_bill_payment(create_dto());
        }

        public void display(IEnumerable<ICompany> companys)
        {
            ux_company_names.bind_to(companys);
        }

        public void display(IEnumerable<bill_information_dto> bills)
        {
            ux_bil_payments_grid.DataSource = bills.databind();
        }

        add_new_bill_dto create_dto()
        {
            return new add_new_bill_dto
                       {
                           company_name = ux_company_names.SelectedItem.to_string(),
                           due_date = ux_due_date.Value,
                           total = ux_amount.Text.to_double()
                       };
        }
    }
}