using System;
using System.Windows.Forms;
using MoMoney.Presentation.Presenters.Shell;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.updates;

namespace MoMoney.Presentation.Views.Shell
{
    public partial class UnhandledErrorView : ApplicationWindow, IUnhandledErrorView
    {
        ControlAction<EventArgs> close_action = x => { };
        ControlAction<EventArgs> restart_action = x => { };
        readonly IWin32Window window;

        public UnhandledErrorView(IWin32Window window)
        {
            InitializeComponent();
            ux_image.Image = ApplicationImages.Splash;
            ux_image.SizeMode = PictureBoxSizeMode.StretchImage;
            titled("Aw snap... something went wrong!")
                .create_tool_tip_for("Ignore", "Ignore the error and continue working.", close_button)
                .create_tool_tip_for("Restart", "Discard any unsaved changes and restart the application.",
                                     restart_button);

            close_button.Click += (sender, args) => close_action(args);
            restart_button.Click += (sender, args) => restart_action(args);
            this.window = window;
        }

        public void attach_to(IUnhandledErrorPresenter presenter)
        {
            close_action = x => Close();
            restart_action = x => presenter.restart_application();
        }

        public void display(Exception exception)
        {
            ux_message.Text = exception.ToString();
            ShowDialog(window);
        }
    }
}