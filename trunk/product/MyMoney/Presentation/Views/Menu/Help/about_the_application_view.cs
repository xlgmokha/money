using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MyMoney.Presentation.Resources;

namespace MyMoney.Presentation.Views.Menu.Help
{
    public partial class about_the_application_view : Form, IAboutApplicationView
    {
        public about_the_application_view()
        {
            InitializeComponent();
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = string.Format("Version {0} {0}", AssemblyVersion);
            uxCopyright.Text = AssemblyCopyright;
            uxCompanyName.Text = AssemblyCompany;
            uxDescription.Text = AssemblyDescription;
            ux_logo.Image = ApplicationImages.Splash;
        }

        public void display()
        {
            ShowDialog();
        }

        public string AssemblyTitle
        {
            get
            {
                var attributes = GetType().Assembly.GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
                if (attributes.Length > 0) {
                    var titleAttribute = (AssemblyTitleAttribute) attributes[0];
                    if (titleAttribute.Title != "") {
                        return titleAttribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get { return GetType().Assembly.GetName().Version.ToString(); }
        }

        public string AssemblyDescription
        {
            get
            {
                var attributes =
                    GetType().Assembly.GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyDescriptionAttribute) attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var attributes = GetType().Assembly.GetCustomAttributes(typeof (AssemblyProductAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyProductAttribute) attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var attributes = GetType().Assembly.GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                var attributes =
                    GetType().Assembly.GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyCompanyAttribute) attributes[0]).Company;
            }
        }
    }
}