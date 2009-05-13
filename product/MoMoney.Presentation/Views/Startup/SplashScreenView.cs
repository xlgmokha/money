using System;
using System.Windows.Forms;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Startup
{
    public partial class SplashScreenView : ApplicationWindow, ISplashScreenView
    {
        public SplashScreenView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Opacity = 0;
            BackgroundImage = ApplicationImages.Splash;
            ClientSize = BackgroundImage.Size;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            top_most();
        }

        public void increment_the_opacity()
        {
            Opacity += 0.2;
        }

        public double current_opacity()
        {
            return Opacity;
        }

        public void decrement_the_opacity()
        {
            Opacity -= .1;
        }

        public void close_the_screen()
        {
            Close();
            Dispose();
        }

        public void display()
        {
            Show();
        }
    }
}