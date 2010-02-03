using System;
using System.Windows.Forms;
using momoney.presentation.views;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Winforms.Views
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
            safely(() =>
            {
                Opacity += 0.2;
            });
        }

        public double current_opacity()
        {
            return Opacity;
        }

        public void decrement_the_opacity()
        {
            safely(() =>
            {
                Opacity -= .1;
            });
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

        void safely(Action action)
        {
            if (InvokeRequired) BeginInvoke(action);
            else action();
        }
    }
}