using System;
using System.Windows.Forms;
using momoney.presentation.presenters;
using momoney.presentation.resources;
using momoney.presentation.views;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class UnhandledErrorView : ApplicationWindow, IUnhandledErrorView
    {
        ControlAction<EventArgs> close_action = x => { };
        ControlAction<EventArgs> restart_action = x => { };

        public UnhandledErrorView()
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
        }

        public void attach_to(UnhandledErrorPresenter presenter)
        {
            close_action = x => presenter.close();
            restart_action = x => presenter.restart_application();
        }

        public void display(Exception exception)
        {
            ux_message.Text = exception.ToString();
        }

        public void show_dialog(Shell parent_window)
        {
            ShowDialog(parent_window);
        }
    }
}