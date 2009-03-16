using System;
using System.Windows.Forms;
using MoMoney.Presentation.Presenters.Shell;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Shell
{
    public partial class UnhandledErrorView : ApplicationWindow, IUnhandledErrorView
    {
        public UnhandledErrorView()
        {
            InitializeComponent();
            ux_image.Image = ApplicationImages.Splash;
            ux_image.SizeMode = PictureBoxSizeMode.StretchImage;
            titled("Aw snap... something went wrong!")
                .create_tool_tip_for("Ignore", "Ignore the error and continue working.", close_button)
                .create_tool_tip_for("Restart", "Discard any unsaved changes and restart the application.",
                                     restart_button);
        }

        public void attach_to(IUnhandledErrorPresenter presenter)
        {
            on_ui_thread(() =>
                             {
                                 close_button.Click += (sender, args) => Close();
                                 restart_button.Click += (sender, args) => presenter.restart_application();
                             });
        }

        public void display(Exception exception)
        {
            on_ui_thread(() =>
                             {
                                 ux_message.Text = exception.ToString();
                                 ShowDialog();
                             });
        }
    }
}