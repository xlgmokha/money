using System.Reflection;
using System.Windows.Forms;
using MoMoney.Domain.Core;
using MoMoney.Presentation.Model.updates;
using MoMoney.Presentation.Presenters.updates;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.updates
{
    public partial class CheckForUpdatesView : ApplicationWindow, ICheckForUpdatesView
    {
        ICheckForUpdatesPresenter the_presenter;

        public CheckForUpdatesView()
        {
            InitializeComponent();
            ux_image.Image = ApplicationImages.Splash;
            ux_image.SizeMode = PictureBoxSizeMode.StretchImage;

            titled("Check For Updates")
                .create_tool_tip_for("Update", "Update the application, and then re-start it.", ux_update_button)
                .create_tool_tip_for("Don't Update", "Discard the latest version.", ux_dont_update_button)
                .create_tool_tip_for("Cancel", "Go back.", ux_cancel_button);
        }

        public void attach_to(ICheckForUpdatesPresenter presenter)
        {
            on_ui_thread(() =>
                             {
                                 ux_update_button.Click += (sender, e) =>
                                                               {
                                                                   ux_update_button.Enabled = false;
                                                                   ux_dont_update_button.Enabled = false;
                                                                   ux_cancel_button.Enabled = true;
                                                                   presenter.begin_update();
                                                               };
                                 ux_dont_update_button.Click += (sender, e) => presenter.do_not_update();
                                 ux_cancel_button.Click += (sender, e) => presenter.cancel_update();
                                 the_presenter = presenter;
                             });
        }

        public void display()
        {
            on_ui_thread(() =>
                             {
                                 ux_update_button.Enabled = false;
                                 ux_dont_update_button.Enabled = false;
                                 ux_cancel_button.Enabled = false;
                                 Show();
                             });
        }

        public void downloaded(Percent percentage_complete)
        {
            on_ui_thread(() =>
                             {
                                 while (percentage_complete.is_less_than(progress_bar.Value))
                                 {
                                     if (percentage_complete.represents(progress_bar.Value))
                                         break;

                                     progress_bar.PerformStep();
                                 }
                             });
        }

        public void update_complete()
        {
            the_presenter.restart();
        }

        public void close()
        {
            on_ui_thread(() => { Close(); });
        }

        public void run(ApplicationVersion information)
        {
            on_ui_thread(
                () =>
                    {
                        if (information.updates_available)
                        {
                            ux_update_button.Enabled = true;
                            ux_dont_update_button.Enabled = true;
                            ux_cancel_button.Enabled = true;
                            ux_update_button.Enabled = information.updates_available;
                            ux_current_version.Text = "Current: " + information.current;
                            ux_new_version.Text = "New: " + information.available_version;
                        }
                        else
                        {
                            ux_update_button.Enabled = false;
                            ux_dont_update_button.Enabled = true;
                            ux_cancel_button.Enabled = false;
                            ux_current_version.Text = "Current: " +
                                                      Assembly.GetExecutingAssembly().GetName().Version;
                            ux_new_version.Text = "New: " + Assembly.GetExecutingAssembly().GetName().Version;
                        }
                    });
        }
    }
}