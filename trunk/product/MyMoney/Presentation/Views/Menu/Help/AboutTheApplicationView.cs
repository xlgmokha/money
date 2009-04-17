using System;
using System.Reflection;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Menu.Help
{
    public partial class AboutTheApplicationView : ApplicationDockedWindow, IAboutApplicationView
    {
        public AboutTheApplicationView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            var assembly = GetType().Assembly;
            labelProductName.Text = assembly.get_attribute<AssemblyProductAttribute>().Product;
            labelVersion.Text = string.Format("Version {0} {0}", assembly_version);
            uxCopyright.Text = assembly.get_attribute<AssemblyCopyrightAttribute>().Copyright;
            uxCompanyName.Text = assembly.get_attribute<AssemblyCompanyAttribute>().Company;
            uxDescription.Text = assembly.get_attribute<AssemblyDescriptionAttribute>().Description;
            ux_logo.Image = ApplicationImages.Splash;
        }

        public void display()
        {
        }

        string assembly_version
        {
            get { return GetType().Assembly.GetName().Version.ToString(); }
        }
    }
}