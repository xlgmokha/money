using MoMoney.Presentation.Model.Menu.File.Commands;
using MoMoney.Presentation.Resources;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Shell
{
    public partial class WelcomeScreen : ApplicationDockedWindow, IGettingStartedView
    {
        readonly IShell shell;

        public WelcomeScreen(IShell shell)
        {
            this.shell = shell;
            InitializeComponent();
            titled("Getting Started");
            //base.BackgroundImage = ApplicationImages.Welcome;
            //base.BackgroundImageLayout = ImageLayout.Center;
        }

        public void display()
        {
            ux_open_existing_file_button.will_be_shown_as(ApplicationImages.OpenExistingFile)
                .when_hovered_over_will_show(ApplicationImages.OpenExistingFileSelected)
                .will_execute<IOpenCommand>(() => true)
                .with_tool_tip("Open Existing File", "Open an existing project.");

            ux_create_new_file_button.will_be_shown_as(ApplicationImages.CreateNewFile)
                .when_hovered_over_will_show(ApplicationImages.CreateNewFileSelected)
                .will_execute<INewCommand>(() => true)
                .with_tool_tip("Create New File", "Create a new project.");

            //ux_company_details_button
            //    .will_be_shown_as(ApplicationImages.CompanyDetails)
            //    .when_hovered_over_will_show(ApplicationImages.CompanyDetailsSelected)
            //    .will_execute<ICompanyTreeNode>(is_there_a_protocol_selected)
            //    .with_tool_tip("Company Details", "Capture the company details.");

            //ux_generate_report_button
            //    .will_be_shown_as(ApplicationImages.GenerateReport)
            //    .when_hovered_over_will_show(ApplicationImages.GenerateReportSelected)
            //    .will_execute<IGenerateReportCommand>(is_there_a_protocol_selected)
            //    .with_tool_tip("Generate Report", "Generate a printable report.");
            shell.add(this);
        }
    }
}