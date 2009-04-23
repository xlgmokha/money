using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gorilla.Commons.Utility.Extensions;
using Gorilla.Commons.Windows.Forms;
using Gorilla.Commons.Windows.Forms.Helpers;
using Gorilla.Commons.Windows.Forms.Krypton;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters.income;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.income
{
    public partial class AddNewIncomeView : ApplicationDockedWindow, IAddNewIncomeView
    {
        ControlAction<EventArgs> submit_button = x => { };
        readonly IBindableList<CompanyDTO> companies_list;

        public AddNewIncomeView()
        {
            InitializeComponent();
            titled("Add Income");
            ux_submit_button.Click += (sender, e) => submit_button(e);

            companies_list = ux_companys.create_for<CompanyDTO>();
        }

        public void attach_to(IAddNewIncomePresenter presenter)
        {
            submit_button = x => presenter.submit_new(create_income());
        }

        public void run(IEnumerable<CompanyDTO> companies)
        {
            companies_list.bind_to(companies);
            //ux_companys.bind_to(companies);
        }

        public void run(IEnumerable<IncomeInformationDTO> incomes)
        {
            ux_income_received_grid.DataSource = incomes.databind();
        }

        IncomeSubmissionDto create_income()
        {
            return new IncomeSubmissionDto
                       {
                           company_id = companies_list.get_selected_item().id,
                           amount = ux_amount.Text.to_double(),
                           recieved_date = ux_date_received.Value
                       };
        }
    }
}