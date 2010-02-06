using System;
using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.DTO;
using momoney.presentation.presenters;
using momoney.presentation.resources;
using momoney.presentation.views;
using MoMoney.Presentation.Winforms.Helpers;
using MoMoney.Presentation.Winforms.Krypton;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class AddBillPaymentView : ApplicationDockedWindow, IAddBillPaymentView
    {
        ControlAction<EventArgs> submit_clicked = x => { };
        readonly IBindableList<CompanyDTO> companies_list;

        public AddBillPaymentView()
        {
            InitializeComponent();
            titled("Add Bill Payment").icon(ApplicationIcons.AddBillPayment);
            ux_submit_button.Click += (sender, e) => submit_clicked(e);
            companies_list = ux_company_names.create_for<CompanyDTO>();
        }

        public void attach_to(AddBillPaymentPresenter presenter)
        {
            submit_clicked = x => presenter.submit_bill_payment(create_dto());
        }

        public void run_against(IEnumerable<CompanyDTO> companys)
        {
            companies_list.bind_to(companys);
        }

        public void run_against(IEnumerable<BillInformationDTO> bills)
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