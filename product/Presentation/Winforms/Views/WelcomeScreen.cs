using momoney.presentation.model.menu.file;
using momoney.presentation.presenters;
using momoney.presentation.views;
using MoMoney.Presentation.Winforms.Helpers;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Winforms.Views
{
    public partial class WelcomeScreen : ApplicationDockedWindow, IGettingStartedView
    {
        public WelcomeScreen()
        {
            InitializeComponent();
            titled("Getting Started").icon(ApplicationIcons.Home);

            ux_open_existing_file_button.will_be_shown_as(ApplicationImages.OpenExistingFile)
                .when_hovered_over_will_show(ApplicationImages.OpenExistingFileSelected)
                .will_execute<IOpenCommand>(() => true)
                .with_tool_tip("Open Existing File", "Open an existing project.");

            ux_create_new_file_button.will_be_shown_as(ApplicationImages.CreateNewFile)
                .when_hovered_over_will_show(ApplicationImages.CreateNewFileSelected)
                .will_execute<INewCommand>(() => true)
                .with_tool_tip("Create New File", "Create a new project.");
        }

        public void attach_to(IGettingStartedPresenter presenter)
        {
        }
    }
}