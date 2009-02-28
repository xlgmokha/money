using System.Windows.Forms;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.Startup
{
    public partial class splash_screen_view : ApplicationWindow, ISplashScreenView
    {
        public splash_screen_view()
        {
            InitializeComponent();
            ApplyWindowStyles();
        }

        void ApplyWindowStyles()
        {
            BackgroundImage = ApplicationImages.Splash;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            if (null != BackgroundImage)
            {
                ClientSize = BackgroundImage.Size;
            }
            TopMost = true;
            Opacity = 0;
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