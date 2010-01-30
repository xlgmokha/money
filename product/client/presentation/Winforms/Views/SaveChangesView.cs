using System;
using System.ComponentModel;
using System.Windows.Forms;
using MoMoney.Presentation.Model.Menu.File;
using momoney.presentation.views;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class SaveChangesView : ApplicationWindow, ISaveChangesView
    {
        readonly IWin32Window window;
        bool can_be_closed;
        ControlAction<EventArgs> save_action = x => { };
        ControlAction<EventArgs> do_not_save_action = x => { };
        ControlAction<EventArgs> cancel_action = x => { };
        ControlAction<CancelEventArgs> closing_action = x => { };

        public SaveChangesView(IWin32Window window)
        {
            this.window = window;
            InitializeComponent();
            ux_image.Image = ApplicationImages.Splash;
            ux_image.SizeMode = PictureBoxSizeMode.StretchImage;

            titled("Unsaved Changes")
                .create_tool_tip_for("Save", "Save the document, and then close it.", save_button)
                .create_tool_tip_for("Don't Save", "Discard any unsaved changes.", do_not_save_button)
                .create_tool_tip_for("Cancel", "Go back.", cancel_button);

            save_button.Click += (sender, e) => save_action(e);
            do_not_save_button.Click += (sender, e) => do_not_save_action(e);
            cancel_button.Click += (sender, e) => cancel_action(e);
            Closing += (sender, e) => closing_action(e);
        }

        public void attach_to(SaveChangesPresenter presenter)
        {
            can_be_closed = false;
            save_action = x => { execute(presenter.save); };
            do_not_save_action = x => { execute(presenter.dont_save); };
            cancel_action = x => { execute(presenter.cancel); };
            closing_action = x => { if (!can_be_closed) presenter.cancel(); };
        }

        public void prompt_user_to_save()
        {
            ShowDialog(window);
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