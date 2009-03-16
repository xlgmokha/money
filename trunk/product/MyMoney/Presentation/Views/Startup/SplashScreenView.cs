using System.Windows.Forms;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Startup
{
    public partial class SplashScreenView : ApplicationWindow, ISplashScreenView
    {
        readonly TextBox progress_textbox;

        public SplashScreenView()
        {
            InitializeComponent();
            ApplyWindowStyles();

            progress_textbox = new TextBox();
            Controls.Add(progress_textbox);
        }

        void ApplyWindowStyles()
        {
            on_ui_thread(() =>
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
                             });
        }

        public void increment_the_opacity()
        {
            on_ui_thread(() => { Opacity += 0.2; });
        }

        public double current_opacity()
        {
            return Opacity;
        }

        public void decrement_the_opacity()
        {
            on_ui_thread(() => { Opacity -= .1; });
        }

        public void close_the_screen()
        {
            on_ui_thread(() =>
                             {
                                 Close();
                                 Dispose();
                             });
        }

        public void update_progress(notification_message message)
        {
            on_ui_thread(() => { progress_textbox.Text = message; });
        }

        public void display()
        {
            on_ui_thread(Show);
        }
    }
}