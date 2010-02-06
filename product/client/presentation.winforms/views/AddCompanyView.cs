using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using gorilla.commons.utility;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters;
using momoney.presentation.resources;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Databinding;
using View = System.Windows.Forms.View;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class AddCompanyView : ApplicationDockedWindow, IAddCompanyView
    {
        ControlAction<EventArgs> submit_button = x => {};
        readonly RegisterNewCompany dto;

        public AddCompanyView()
        {
            InitializeComponent();
            titled("Add A Company").icon(ApplicationIcons.AddCompany);
            dto = new RegisterNewCompany();

            companiesListView.View = View.LargeIcon;
            companiesListView.LargeImageList = new ImageList();
            ApplicationIcons.all().each(x => companiesListView.LargeImageList.Images.Add(x.name_of_the_icon, x));
            companiesListView.Columns.Add("Name");

            ux_company_name.bind_to(dto, x => x.company_name);
            ux_submit_button.Click += (x, y) => submit_button(y);
            ux_cancel_button.Click += (x, y) => Close();
        }

        public void attach_to(AddCompanyPresenter presenter)
        {
            submit_button = x =>
            {
                presenter.submit(dto);
            };
        }

        public void run_against(IEnumerable<CompanyDTO> companies)
        {
            companiesListView.Items.Clear();
            companiesListView.Items.AddRange(companies.Select(x => new ListViewItem(x.name, 0)).ToArray());
        }
    }
}