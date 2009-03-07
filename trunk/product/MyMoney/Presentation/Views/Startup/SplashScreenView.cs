using System.Windows.Forms;
using Castle.Core;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Startup
{
    [Interceptor(typeof (ISynchronizedInterceptor))]
    public partial class SplashScreenView : ApplicationWindow, ISplashScreenView
    {
        public SplashScreenView()
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