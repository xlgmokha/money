using System.Windows.Forms;
using MyMoney.Presentation.Model.updates;
using MyMoney.Presentation.Presenters.updates;
using MyMoney.Presentation.Resources;

namespace MyMoney.Presentation.Views.updates
{
    public partial class check_for_updates : Form, ICheckForUpdatesView
    {
        public check_for_updates()
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
            }
            ShowDialog();
        }

        public void update_complete()
        {
            MessageBox.Show("update complete", "Complete");
        }

        private void create_tool_tip_for(string title, string caption, Control control)
        {
            new ToolTip {IsBalloon = true, ToolTipTitle = title}.SetToolTip(control, caption);
        }
    }
}