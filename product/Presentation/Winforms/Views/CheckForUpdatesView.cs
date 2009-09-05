using System;
using System.Reflection;
using System.Windows.Forms;
using Gorilla.Commons.Utility;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters.updates;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.Core;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Views.updates
{
    public partial class CheckForUpdatesView : ApplicationWindow, ICheckForUpdatesView
    {
        readonly IShell shell;
        ControlAction<EventArgs> update_button;
        ControlAction<EventArgs> dont_update_button;
        ControlAction<EventArgs> cancel_button;

        public CheckForUpdatesView(IShell shell)
        {
            InitializeComponent();

            this.shell = shell;
            ux_image.Image = ApplicationImages.Splash;
            ux_image.SizeMode = PictureBoxSizeMode.StretchImage;

            titled("Check For Updates")
                .create_tool_tip_for("Update", "Update the application, and then re-start it.", ux_update_button)
                .create_tool_tip_for("Don't Update", "Discard the latest version.", ux_dont_update_button)
                .create_tool_tip_for("Cancel", "Go back.", ux_cancel_button);

            ux_update_button.Click += (o, e) => update_button(e);
            ux_dont_update_button.Click += (o, e) => dont_update_button(e);
            ux_cancel_button.Click += (o, e) => cancel_button(e);
        }

        public void attach_to(ICheckForUpdatesPresenter presenter)
        {
            update_button = x =>
                                {
                                    ux_update_button.Enabled = false;
                                    ux_dont_update_button.Enabled = false;
                                    ux_cancel_button.Enabled = true;
                                    presenter.begin_update();
                                };
            dont_update_button = x => presenter.do_not_update();
            cancel_button = x => presenter.cancel_update();
        }

        public void display()
        {
            ux_update_button.Enabled = false;
            ux_dont_update_button.Enabled = false;
            ux_cancel_button.Enabled = false;
            Show(shell);
        }

        public void downloaded(Percent percentage_complete)
        {
            shell.region<ToolStripProgressBar>(
                x =>
                    {
                        while (percentage_complete.is_less_than(x.Value))
                        {
                            if (percentage_complete.represents(x.Value)) break;
                            x.PerformStep();
                        }
                    });
        }

        public void update_complete()
        {
            downloaded(100);
        }

        public void close()
        {
            Close();
        }

        public void run(ApplicationVersion information)
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
                ux_current_version.Text = "Current: " + Assembly.GetExecutingAssembly().GetName().Version;
                ux_new_version.Text = "New: " + Assembly.GetExecutingAssembly().GetName().Version;
            }
        }
    }
}