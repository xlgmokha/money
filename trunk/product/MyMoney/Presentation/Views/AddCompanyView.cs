using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Databindings;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Views
{
    public partial class AddCompanyView : ApplicationDockedWindow, IAddCompanyView
    {
        readonly RegisterNewCompany dto;

        public AddCompanyView()
        {
            InitializeComponent();
            titled("Add A Company");
            dto = new RegisterNewCompany();

            initialize1();
        }

        void initialize1()
        {
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = new ImageList();
            ApplicationIcons.all().each(x => listView1.LargeImageList.Images.Add(x.name_of_the_icon, x));
            listView1.Columns.Add("Name");
        }

        public void attach_to(IAddCompanyPresenter presenter)
        {
            ux_company_name.bind_to(dto, x => x.company_name);
            ux_submit_button.Click += (x, y) => presenter.submit(dto);
            ux_cancel_button.Click += (x, y) => Dispose();
        }

        public void run(IEnumerable<ICompany> companies)
        {
            ux_companys_listing.DataSource = companies.databind();

            listView1.Items.Clear();
            listView1.Items.AddRange(companies.Select(x => new ListViewItem(x.name, 3)).ToArray());
        }

        public void notify(params notification_message[] messages)
        {
            var builder = new StringBuilder();
            messages.each(x => builder.Append(x));
            MessageBox.Show(builder.ToString());
        }
    }
}