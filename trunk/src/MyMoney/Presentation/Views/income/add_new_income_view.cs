using System;
using System.Collections.Generic;
using MyMoney.Domain.accounting.billing;
using MyMoney.Presentation.Model.interaction;
using MyMoney.Presentation.Presenters.income;
using MyMoney.Presentation.Presenters.income.dto;
using MyMoney.Utility.Extensions;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMoney.Presentation.Views.income
{
    public partial class add_new_income_view : DockContent, IAddNewIncomeView
    {
        public add_new_income_view()
        {
            InitializeComponent();
            TabText = "Add Income";
        }

        public void attach_to(IAddNewIncomePresenter presenter)
        {
            ux_submit_button.Click += (sender, e) => presenter.submit_new(create_income());
        }

        public void display(IEnumerable<ICompany> companys)
        {
            ux_companys.bind_to(companys);
        }

        public void display(IEnumerable<income_information_dto> incomes)
        {
            ux_income_received_grid.DataSource = incomes.databind();
        }

        public void notify(params notification_message[] messages)
        {
            throw new NotImplementedException();
        }

        private income_submission_dto create_income()
        {
            return new income_submission_dto
                       {
                           company = ux_companys.SelectedItem.downcast_to<ICompany>(),
                           amount = ux_amount.Text.to_double(),
                           recieved_date = ux_date_received.Value
                       };
        }
    }
}