using System;
using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters;
using momoney.presentation.resources;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Helpers;
using MoMoney.Presentation.Winforms.Krypton;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class AddNewIncomeView : ApplicationDockedWindow, IAddNewIncomeView
    {
        ControlAction<EventArgs> submit_button = x => { };
        readonly IBindableList<CompanyDTO> companies_list;

        public AddNewIncomeView()
        {
            InitializeComponent();
            titled("Add Income")
                .icon(ApplicationIcons.AddNewIncome);
            ux_submit_button.Click += (sender, e) => submit_button(e);

            companies_list = ux_companys.create_for<CompanyDTO>();
        }

        public void attach_to(AddNewIncomePresenter presenter)
        {
            submit_button = x => presenter.submit_new(create_income());
        }

        public void run_against(IEnumerable<CompanyDTO> companies)
        {
            companies_list.bind_to(companies);
        }

        public void run_against(IEnumerable<IncomeInformationDTO> incomes)
        {
            ux_income_received_grid.DataSource = incomes.databind();
        }

        IncomeSubmissionDTO create_income()
        {
            return new IncomeSubmissionDTO
                       {
                           company_id = companies_list.get_selected_item().id,
                           amount = ux_amount.Text.to_double(),
                           recieved_date = ux_date_received.Value
                       };
        }
    }
}