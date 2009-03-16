using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MoMoney.Domain.accounting.billing;
using MoMoney.Infrastructure.Extensions;
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
        readonly register_new_company dto;

        public AddCompanyView()
        {
            InitializeComponent();
            titled("Add A Company");
            dto = new register_new_company();

            initialize1();
            initialize2();
        }

        void initialize1()
        {
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = new ImageList();
            ApplicationIcons.all().each(x => listView1.LargeImageList.Images.Add(x.name_of_the_icon, x));
            listView1.Columns.Add("Name");
        }

        void initialize2()
        {
            listView2.View = View.Details;
            listView2.Columns.Add("Name");
            ux_company_search_textbox.TextChanged += (sender, args) =>
                                                         {
                                                             var foundItem =
                                                                 listView2.FindItemWithText(
                                                                     ux_company_search_textbox.Text, false, 0, true);
                                                             if (foundItem != null)
                                                             {
                                                                 listView2.TopItem = foundItem;
                                                             }
                                                         };
        }

        public void attach_to(IAddCompanyPresenter presenter)
        {
            ux_company_name.bind_to(dto, x => x.company_name);
            ux_submit_button.Click += (x, y) => presenter.submit(dto);
            ux_cancel_button.Click += (x, y) => Dispose();
        }

        public void display(IEnumerable<ICompany> companies)
        {
            this.log().debug("companys to display {0}", companies.Count());
            if (companies.Count() > 0)
            {
                //this.log().debug("companys 1 display {0}", companies.ElementAt(0));
                //this.log().debug("companys 2 display {0}", companies.ElementAt(1));
                companies.each(x => this.log().debug("company {0}", x));
            }
            ux_companys_listing.DataSource = companies.databind();

            listView1.Items.Clear();
            listView1.Items.AddRange(companies.Select(x => new ListViewItem(x.name, 2)).ToArray());

            listView2.Items.Clear();
            listView2.Items.AddRange(companies.Select(x => new ListViewItem(x.name)).ToArray());

            //var tlist = new TypedObjectListView<ICompany>(objectListView1);
            //tlist.GetColumn(0).AspectGetter = (ICompany x) => x.name;
            objectListView1.SetObjects(companies.ToList());
        }

        public void notify(params notification_message[] messages)
        {
            var builder = new StringBuilder();
            messages.each(x => builder.Append(x));
            MessageBox.Show(builder.ToString());
        }
    }
}