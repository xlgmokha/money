using System.Reflection;
using System.Windows.Forms;
using MyMoney.Presentation.Model.updates;
using MyMoney.Presentation.Presenters.updates;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.updates
{
    public partial class check_for_updates : ApplicationForm, ICheckForUpdatesView
    {
        public check_for_updates() : base("Check For Updates")
        {
            InitializeComponent();
            ux_image.Image = ApplicationImages.Splash;
            ux_image.SizeMode = PictureBoxSizeMode.StretchImage;
            create_tool_tip_for("Update", "Update the application, and then re-start it.", ux_update_button);
            create_tool_tip_for("Don't Update", "Discard the latest version.", ux_dont_update_button);
            create_tool_tip_for("Cancel", "Go back.", ux_cancel_button);
        }

        public void attach_to(ICheckForUpdatesPresenter presenter)
        {
            ux_update_button.Click += (sender, e) => presenter.begin_update();
            ux_dont_update_button.Click += (sender, e) => presenter.do_not_update();
            ux_cancel_button.Click += (sender, e) => presenter.cancel_update();
        }

        public void display(ApplicationVersion information)
        {
            if (information.updates_available)
            {
                ux_update_button.Enabled = information.updates_available;
                ux_current_version.Text = "Current: " + information.current;
                ux_new_version.Text = "New: " + information.available_version;
            }
            else
            {
                ux_current_version.Text = "Current: " + Assembly.GetExecutingAssembly().GetName().Version;
                ux_new_version.Text = "New: " + Assembly.GetExecutingAssembly().GetName().Version;
            }
            ShowDialog();
        }

        public void update_complete()
        {
            MessageBox.Show("update complete", "Complete");
        }
    }
}