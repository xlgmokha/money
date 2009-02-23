using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MyMoney.Domain.accounting.billing;
using MyMoney.Presentation.Databindings;
using MyMoney.Presentation.Model.interaction;
using MyMoney.Presentation.Presenters;
using MyMoney.Presentation.Presenters.billing.dto;
using MyMoney.Utility.Extensions;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMoney.Presentation.Views
{
    public partial class add_new_company_view : DockContent, IAddCompanyView
    {
        private readonly register_new_company dto;

        public add_new_company_view()
        {
            InitializeComponent();
            TabText = "Add A Company";
            dto = new register_new_company();
        }

        public void attach_to(IAddCompanyPresenter presenter)
        {
            ux_company_name.bind_to(dto, x => x.company_name);
            ux_submit_button.Click += (x, y) => presenter.submit(dto);
            ux_cancel_button.Click += (x, y) => Dispose();
        }

        public void display(IEnumerable<ICompany> companies)
        {
            ux_companys_listing.DataSource = companies.databind();
        }

        public void notify(params notification_message[] messages)
        {
            var builder = new StringBuilder();
            messages.each(x => builder.Append(x));
            MessageBox.Show(builder.ToString());
        }


    }
}