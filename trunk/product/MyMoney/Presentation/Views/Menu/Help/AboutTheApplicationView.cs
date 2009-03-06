using System.Linq;
using System.Reflection;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Views.Menu.Help
{
    public partial class AboutTheApplicationView : ApplicationWindow, IAboutApplicationView
    {
        public AboutTheApplicationView()
        {
            InitializeComponent();
            labelProductName.Text = get_attribute<AssemblyProductAttribute>().Product;
            labelVersion.Text = string.Format("Version {0} {0}", AssemblyVersion);
            uxCopyright.Text = get_attribute<AssemblyCopyrightAttribute>().Copyright;
            uxCompanyName.Text = get_attribute<AssemblyCompanyAttribute>().Company;
            uxDescription.Text = get_attribute<AssemblyDescriptionAttribute>().Description;
            ux_logo.Image = ApplicationImages.Splash;
        }

        public void display()
        {
            ShowDialog();
        }

        string AssemblyVersion
        {
            get { return GetType().Assembly.GetName().Version.ToString(); }
        }

        Attribute get_attribute<Attribute>() where Attribute : System.Attribute
        {
            return
                GetType()
                    .Assembly
                    .GetCustomAttributes(typeof (Attribute), false)
                    .Select(x => x.downcast_to<Attribute>())
                    .First();
        }
    }
}