using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gorilla.Commons.Utility.Extensions;
using Gorilla.Commons.Windows.Forms;
using Gorilla.Commons.Windows.Forms.Databinding;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views
{
    public partial class AddCompanyView : ApplicationDockedWindow, IAddCompanyView
    {
        ControlAction<EventArgs> submit_button = x => { };
        readonly RegisterNewCompany dto;

        public AddCompanyView()
        {
            InitializeComponent();
            titled("Add A Company");
            dto = new RegisterNewCompany();

            listView1.View = View.LargeIcon;
            listView1.LargeImageList = new ImageList();
            ApplicationIcons.all().each(x => listView1.LargeImageList.Images.Add(x.name_of_the_icon, x));
            listView1.Columns.Add("Name");

            ux_submit_button.Click += (x, y) => submit_button(y);
            ux_cancel_button.Click += (x, y) => Close();
        }

        public void attach_to(IAddCompanyPresenter presenter)
        {
            ux_company_name.bind_to(dto, x => x.company_name);
            submit_button = x => presenter.submit(dto);
        }

        public void run(IEnumerable<CompanyDTO> companies)
        {
            ux_companys_listing.DataSource = companies.databind();

            listView1.Items.Clear();
            listView1.Items.AddRange(companies.Select(x => new ListViewItem(x.name, 0)).ToArray());
        }
    }
}