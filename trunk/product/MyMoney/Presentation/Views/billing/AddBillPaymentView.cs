using System;
using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Databindings;
using MoMoney.Presentation.Presenters.billing;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.updates;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Views.billing
{
    public partial class AddBillPaymentView : ApplicationDockedWindow, IAddBillPaymentView
    {
        ControlAction<EventArgs> submit_clicked = x => { };

         ControlAction<EventArgs> activated = x => { };

        public AddBillPaymentView()
        {
            InitializeComponent();
            titled("Add Bill Payment");
            ux_submit_button.Click += (sender, e) => submit_clicked(e);
            Activated += (sender, args) => activated(args);
        }

        public void attach_to(IAddBillPaymentPresenter presenter)
        {
            submit_clicked = x => presenter.submit_bill_payment(create_dto());
        }

        public void run(IEnumerable<ICompany> companys)
        {
            ux_company_names.bind_to(companys);
        }

        public void run(IEnumerable<BillInformationDTO> bills)
        {
            ux_bil_payments_grid.DataSource = bills.databind();
        }

        AddNewBillDTO create_dto()
        {
            return new AddNewBillDTO
                       {
                           company_name = ux_company_names.SelectedItem.to_string(),
                           due_date = ux_due_date.Value,
                           total = ux_amount.Text.to_double()
                       };
        }
    }
}