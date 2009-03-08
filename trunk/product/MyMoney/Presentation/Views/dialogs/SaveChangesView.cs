using System;
using System.Windows.Forms;
using JetBrains.Annotations;
using MoMoney.Presentation.Model.Menu.File.Commands;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.dialogs
{
    [UsedImplicitly]
    public partial class SaveChangesView : ApplicationWindow, ISaveChangesView
    {
        bool can_be_closed;

        public SaveChangesView()
        {
            InitializeComponent();
            ux_image.Image = ApplicationImages.Splash;
            ux_image.SizeMode = PictureBoxSizeMode.StretchImage;

            titled("Unsaved Changes")
                .create_tool_tip_for("Save", "Save the document, and then close it.", ux_save_button)
                .create_tool_tip_for("Don't Save", "Discard the unsaved changes.", ux_do_not_save_button)
                .create_tool_tip_for("Cancel", "Go back.", ux_cancel_button);
        }


        public void attach_to(ISaveChangesPresenter presenter)
        {
            ux_save_button.Click += (sender, e) => execute(presenter.save);
            ux_do_not_save_button.Click += (sender, e) => execute(presenter.dont_save);
            ux_cancel_button.Click += (sender, e) => execute(presenter.cancel);
            Closing += (sender, e) => { if (!can_be_closed) presenter.cancel(); };
        }

        public void prompt_user_to_save()
        {
            ShowDialog();
        }

        void execute(Action action)
        {
            can_be_closed = true;
            Hide();
            Close();
            action();
        }
    }
}