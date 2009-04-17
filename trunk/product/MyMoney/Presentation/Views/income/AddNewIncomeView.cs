using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Databindings;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Presentation.Presenters.income;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.income
{
    public partial class AddNewIncomeView : ApplicationDockedWindow, IAddNewIncomeView
    {
        ControlAction<EventArgs> submit_button = x => { };

        public AddNewIncomeView()
        {
            InitializeComponent();
            titled("Add Income");
            ux_submit_button.Click += (sender, e) => submit_button(e);
        }

        public void attach_to(IAddNewIncomePresenter presenter)
        {
            submit_button = x => presenter.submit_new(create_income());
        }

        public void display(IEnumerable<ICompany> companies)
        {
            ux_companys.bind_to(companies);
        }

        public void display(IEnumerable<income_information_dto> incomes)
        {
            ux_income_received_grid.DataSource = incomes.databind();
        }

        public void notify(params notification_message[] messages)
        {
            var builder = new StringBuilder();
            messages.each(x => builder.AppendLine(x));
            MessageBox.Show(builder.ToString(), "Ooops...", MessageBoxButtons.OK);
        }

        IncomeSubmissionDto create_income()
        {
            return new IncomeSubmissionDto
                       {
                           company_id = ux_companys.SelectedItem.downcast_to<ICompany>().id,
                           amount = ux_amount.Text.to_double(),
                           recieved_date = ux_date_received.Value
                       };
        }
    }
}