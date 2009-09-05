using System;
using System.Collections.Generic;
using Gorilla.Commons.Utility.Extensions;
using Gorilla.Commons.Windows.Forms.Helpers;
using Gorilla.Commons.Windows.Forms.Krypton;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters.billing;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.Core;

namespace MoMoney.Presentation.Views.billing
{
    public partial class AddBillPaymentView : ApplicationDockedWindow, IAddBillPaymentView
    {
        ControlAction<EventArgs> submit_clicked = x => { };
        readonly IBindableList<CompanyDTO> companies_list;

        public AddBillPaymentView()
        {
            InitializeComponent();
            titled("Add Bill Payment");
            ux_submit_button.Click += (sender, e) => submit_clicked(e);
            companies_list = ux_company_names.create_for<CompanyDTO>();
        }

        public void attach_to(IAddBillPaymentPresenter presenter)
        {
            submit_clicked = x => presenter.submit_bill_payment(create_dto());
        }

        public void run(IEnumerable<CompanyDTO> companys)
        {
            companies_list.bind_to(companys);
        }

        public void run(IEnumerable<BillInformationDTO> bills)
        {
            ux_bill_payments_grid.DataSource = bills.databind();
        }

        AddNewBillDTO create_dto()
        {
            return new AddNewBillDTO
                       {
                           company_id = companies_list.get_selected_item().id,
                           due_date = ux_due_date.Value,
                           total = ux_amount.Text.to_double()
                       };
        }
    }
}